using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using System.IO;

namespace TicToc
{
    public partial class Form1 : Form
    {
        string pass = "password";
        string programPath;
        string contractAddress = "";
        string url = "http://localhost:8545";
        
        string KeyStorePath = @"E:\BlockChain\TicToc\devChain\keystore\";
        Web3 client;
        string password;
        Account account;
        string appPath;
        Color Xcolor = Color.Aqua;
        Color Ocolor = Color.Yellow;
        public bool GameReady = false;
        public bool BetTurn = false;
        public int ProposedBet = 0;
        public Form1()
        {
            InitializeComponent();
            DialogResult dialogResult = MessageBox.Show("Do you wan to deploy a new game", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dg_file.ShowDialog() == DialogResult.OK)
                {
                    KeyStorePath = dg_file.FileName;
                }
                Deploy();
            }


            programPath = AppDomain.CurrentDomain.BaseDirectory;
            LoadCombo();

        }

        private void bt_deploy_Click(object sender, EventArgs e)
        {
            Deploy();
        }

        private void LoadCombo()
        {
            var list = File.ReadAllLines(programPath + "\\MyContractAddress.txt");
            combo_Contract.Items.Clear();
            combo_Contract.Items.AddRange(list);
        }
        private async void Deploy()
        {
            try
            {
                Account account = Account.LoadFromKeyStoreFile(KeyStorePath, pass);

                Web3 client = new Web3(account, url);
                Deployment deploy = new Deployment();
                var deployHandler = client.Eth.GetContractDeploymentHandler<Deployment>();
                var result = await deployHandler.SendRequestAndWaitForReceiptAsync(deploy);
                var newContractAddress = result.ContractAddress;
                MessageBox.Show(newContractAddress);
                File.AppendAllText(programPath + "\\MyContractAddress.txt", newContractAddress + "\n");
                LoadCombo();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void CheckStatus()
        {
            try
            {

                var status = new GameStatus();
                var q = client.Eth.GetContractQueryHandler<GameStatus>();
                var result = await q.QueryAsync<bool>(status, contractAddress);
                if (result == true)
                    MessageBox.Show("the game is started now");
                else
                    MessageBox.Show("the game is not started");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //var fumsg = new GetCountFunction();
            //var query = chain.Eth.GetContractQueryHandler<GetCountFunction>();
            //var result = await query.QueryAsync<Int32>(fumsg, contractAddress);

        }

        private void bt_status_Click(object sender, EventArgs e)
        {
            CheckStatus();
        }

        private async void SetBet_Click(object sender, EventArgs e)
        {
            try
            {
                if (BetTurn == true)
                {
                    var setBet = new SetBet();
                    setBet.betAmount = Decimal.ToInt32(tx_bet.Value);
                    var handler = client.Eth.GetContractTransactionHandler<SetBet>();
                    var rr = await handler.SendRequestAndWaitForReceiptAsync(setBet, contractAddress);
                    MessageBox.Show("new bet is set");
                    ProposedBet = Decimal.ToInt32(tx_bet.Value);
                    BetTurn = false;
                }
                else
                {
                    MessageBox.Show("wait...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("the balance is not enough");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var am = new BetAmount();
                var q = client.Eth.GetContractQueryHandler<BetAmount>();
                var result = await q.QueryAsync<Int32>(am, contractAddress);
                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void combo_Contract_SelectedIndexChanged(object sender, EventArgs e)
        {
            contractAddress = combo_Contract.SelectedItem.ToString();
            bt_accfile.Enabled = true;
        }

        private async void bt_address_Click(object sender, EventArgs e)
        {
            try
            {
                var q = client.Eth.GetContractQueryHandler<GetAddressfunction>();
                var msg = new GetAddressfunction();
                var result = await q.QueryAsync<System.Numerics.BigInteger>(msg, contractAddress);
                MessageBox.Show(result.ToString("x"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void bt_addplayer_Click(object sender, EventArgs e)
        {
            try
            {
                ProposedBet = 0;
                tx_bet.Value = 0;
                var handler = client.Eth.GetContractTransactionHandler<AddPlayerFunction>();
                var add = new AddPlayerFunction();
                await handler.SendRequestAndWaitForReceiptAsync(add, contractAddress);

                var turn = new GetTurnFunction();
                var handler2 = client.Eth.GetContractQueryHandler<GetTurnFunction>();
                var result = await handler2.QueryAsync<bool>(turn, contractAddress);
                if (result == true)
                    BetTurn = true;
                else
                    BetTurn = false;
                MessageBox.Show("new player added");
                timer1.Start();
                pn_player.Enabled = false;
                pn_bet.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<Color> Mark(int i, int j)
        {
            var handler2 = client.Eth.GetContractQueryHandler<GetBoradSquareFunction>();
            var state = new GetBoradSquareFunction();
            state.Row = i;
            state.Column = j;
            var cellStatus = await handler2.QueryAsync<string>(state, contractAddress);

            if (cellStatus == "N")
            {
                SetMarkFunction mark = new SetMarkFunction();
                mark.Row = i;
                mark.Column = j;
                var handler = client.Eth.GetContractTransactionHandler<SetMarkFunction>();
                var rr = await handler.SendRequestAndWaitForReceiptAsync(mark, contractAddress);
                cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                if (cellStatus == "X")
                    return Xcolor;
                else if (cellStatus == "O")
                    return Ocolor;
            }
            return Color.Transparent;

        }

        private void bt_accfile_Click(object sender, EventArgs e)
        {

            if (dg_file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    KeyStorePath = dg_file.FileName;
                    password = "password";
                    account = Account.LoadFromKeyStoreFile(KeyStorePath, password);
                    client = new Web3(account, url);
                    pn_contract.Enabled = false;
                    pn_player.Enabled = true;
                    //Init();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(row, col);
        }

        private async void CellClick(Button button)
        {
            var s = button.Tag.ToString();
            var color = await Mark(Int32.Parse(s.Split('_')[0].ToString()), Int32.Parse(s.Split('_')[1].ToString()));
            button.BackColor = color;
        }

        private void bt_00_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_01_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_02_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_10_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_11_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_12_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_20_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_21_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private void bt_22_Click(object sender, EventArgs e)
        {
            CellClick((Button)sender);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var q = client.Eth.GetContractQueryHandler<GetAddressfunction>();
            var msg = new GetAddressfunction();
            var result = await q.QueryAsync<System.Numerics.BigInteger>(msg, contractAddress);
            MessageBox.Show(result.ToString("x"));
        }

        private async void GetGameBoard()
        {
            try
            {
                if (GameReady == false)
                {
                    var status = new GameStatus();
                    var q = client.Eth.GetContractQueryHandler<GameStatus>();
                    var ready = await q.QueryAsync<bool>(status, contractAddress);
                    if (ready == true)
                        GameReady = true;
                    else if (BetTurn == false)
                    {
                        var am = new BetAmount();
                        var bet = client.Eth.GetContractQueryHandler<BetAmount>();
                        var result = await bet.QueryAsync<Int32>(am, contractAddress);
                        if (result != ProposedBet)
                            BetTurn = true;
                        tx_bet.Value = result;
                    }
                }
                if (GameReady == true)
                {
                    pn_bet.Enabled = false;
                    var handler1 = client.Eth.GetContractQueryHandler<GetWinnerFunction>();
                    var win = new GetWinnerFunction();
                    var winResult = await handler1.QueryAsync<string>(win, contractAddress);
                    if (String.IsNullOrEmpty(winResult.ToString()) == false)
                        timer1.Stop();
                    pnl_Board.Enabled = true;
                    var handler2 = client.Eth.GetContractQueryHandler<GetBoradSquareFunction>();
                    var state = new GetBoradSquareFunction();
                    state.Row = 0;
                    state.Column = 0;
                    var cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_00.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_00.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_00.BackColor = Color.Transparent;

                    state.Row = 0;
                    state.Column = 1;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_01.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_01.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_01.BackColor = Color.Transparent;

                    state.Row = 0;
                    state.Column = 2;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_02.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_02.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_02.BackColor = Color.Transparent;

                    state.Row = 1;
                    state.Column = 0;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_10.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_10.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_10.BackColor = Color.Transparent;

                    state.Row = 1;
                    state.Column = 1;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_11.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_11.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_11.BackColor = Color.Transparent;

                    state.Row = 1;
                    state.Column = 2;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_12.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_12.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_12.BackColor = Color.Transparent;


                    state.Row = 2;
                    state.Column = 0;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_20.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_20.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_20.BackColor = Color.Transparent;

                    state.Row = 2;
                    state.Column = 1;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_21.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_21.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_21.BackColor = Color.Transparent;

                    state.Row = 2;
                    state.Column = 2;
                    cellStatus = await handler2.QueryAsync<string>(state, contractAddress);
                    if (cellStatus == "X")
                        bt_22.BackColor = Xcolor;
                    else if (cellStatus == "O")
                        bt_22.BackColor = Ocolor;
                    else if (cellStatus == "N")
                        bt_22.BackColor = Color.Transparent;

                    if (String.IsNullOrEmpty(winResult.ToString()) == false)
                    {
                        pnl_Board.Enabled = false;
                        pn_player.Enabled = true;
                        GameReady = false;
                        MessageBox.Show(winResult);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            GetGameBoard();
        }

        private void bt_init_Click(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            var handler2 = client.Eth.GetContractTransactionHandler<InitializeFunction>();
            InitializeFunction ini = new InitializeFunction();
            await handler2.SendRequestAndWaitForReceiptAsync(ini, contractAddress);

            var hand = client.Eth.GetContractTransactionHandler<ResetPlayersFunction>();
            var res = new ResetPlayersFunction();
            await hand.SendRequestAndWaitForReceiptAsync(res, contractAddress);
            GameReady = false;
            pn_player.Enabled = true;
            pn_bet.Enabled = false;
            GetGameBoard();
        }

        private async void bt_balance_Click(object sender, EventArgs e)
        {
            var handler2 = client.Eth.GetContractQueryHandler<GetBalanceFunction>();
            GetBalanceFunction ini = new GetBalanceFunction();
            var result = await handler2.QueryAsync<int>(ini, contractAddress);
            MessageBox.Show(result.ToString());
        }
    }


    public class Deployment : ContractDeploymentMessage
    {

        public static string BYTECODE = @"0x60806040526000805534801561001457600080fd5b5061002664010000000061002b810204565b61010f565b6000805b60038210156100d7575060005b60038110156100cc577f4e000000000000000000000000000000000000000000000000000000000000006001836003811061007357fe5b01826003811061007f57fe5b6020810490910180547f0100000000000000000000000000000000000000000000000000000000000000909304601f9092166101000a91820260ff9092021990921617905560010161003c565b60019091019061002f565b505060088054600080556005805460a060020a60ff021916905560078054600160a060020a0319169055600160b060020a0319169055565b61108e8061011e6000396000f3006080604052600436106100c45763ffffffff7c01000000000000000000000000000000000000000000000000000000006000350416631420c81881146100c95780633e8ea9da146100f257806344b45f2a1461010d5780636f26e9071461012757806380f860091461014e57806390747c251461016357806393eee772146101f35780639c083ef6146102155780639f6c4e6c1461022a578063b7f6a98d1461023f578063f109522214610254578063f8f8a91214610285578063fb0950401461029a575b600080fd5b3480156100d557600080fd5b506100de6102af565b604080519115158252519081900360200190f35b3480156100fe57600080fd5b506100de6004356024356102c0565b34801561011957600080fd5b506101256004356104f9565b005b34801561013357600080fd5b5061013c610662565b60408051918252519081900360200190f35b34801561015a57600080fd5b50610125610820565b34801561016f57600080fd5b5061017e6004356024356108ec565b6040805160208082528351818301528351919283929083019185019080838360005b838110156101b85781810151838201526020016101a0565b50505050905090810190601f1680156101e55780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156101ff57600080fd5b50610125600160f860020a031960043516610a31565b34801561022157600080fd5b50610125610ebc565b34801561023657600080fd5b5061017e610eda565b34801561024b57600080fd5b5061013c610fd8565b34801561026057600080fd5b50610269610fde565b60408051600160a060020a039092168252519081900360200190f35b34801561029157600080fd5b5061013c61102b565b3480156102a657600080fd5b506100de61103e565b60055460a060020a900460ff165b90565b60085460009060f960020a602702908290600160a060020a031615156104f15760085460a060020a900460ff16151560011480156103085750600654600160a060020a031633145b8015610322575060055460a060020a900460ff1615156001145b156104f157600454600160a060020a031633141561035657505060055460fb60020a600b0290600160a060020a0316610381565b600554600160a060020a031633141561038157505060045460f860020a604f0290600160a060020a03165b60f960020a602702600160f860020a03198316146104f1576003851080156103aa575060008510155b80156103b65750600384105b80156103c3575060008410155b156104f157600185600381106103d557fe5b0184600381106103e157fe5b602091828204019190069054906101000a900460f860020a02600160f860020a03191660f960020a60270214156104b857816001866003811061042057fe5b01856003811061042c57fe5b60208104909101805460f860020a909304601f9092166101000a91820260ff9092021990921617905560068054600160a060020a038316600160a060020a031990911617905561047b82610a31565b604080516001815290517f691d596d95422129c71f578925682e79de7ea5b43cc614e9df2f6aefde7270639181900360200190a1600192506104f1565b604080516000815290517f691d596d95422129c71f578925682e79de7ea5b43cc614e9df2f6aefde7270639181900360200190a1600092505b505092915050565b60085460a060020a900460ff1615156001141561065f573360009081526009602052604090205481131561058e57604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152601560248201527f62616c616e6365206973206e6f7420656e6f7567680000000000000000000000604482015290519081900360640190fd5b600754600160a060020a0316331480156105b2575060055460a060020a900460ff16155b1561065f576000548114156105ea576005805474ff0000000000000000000000000000000000000000191660a060020a17905561065f565b6000819055600454600160a060020a03163314156106295760055460078054600160a060020a031916600160a060020a0390921691909117905561065f565b600554600160a060020a031633141561065f5760045460078054600160a060020a031916600160a060020a039092169190911790555b50565b600454600090600160a060020a031615156107235761067f610820565b6004805433600160a060020a03199182168117928390556006805483168217905560078054909216179055600160a060020a031660009081526009602052604090205415156106e757600454600160a060020a03166000908152600960205260409020606490555b604080516001815290517fdf32ea5cdb00a2b6e1ed92196a509ab2284717613737fc159ab6518f66b7142e9181900360200190a15060016102bd565b600554600160a060020a031615156107e65760058054600160a060020a0319163317908190556008805474ff0000000000000000000000000000000000000000191660a060020a179055600160a060020a031660009081526009602052604090205415156107aa57600554600160a060020a03166000908152600960205260409020606490555b604080516002815290517fdf32ea5cdb00a2b6e1ed92196a509ab2284717613737fc159ab6518f66b7142e9181900360200190a15060026102bd565b604080516003815290517fdf32ea5cdb00a2b6e1ed92196a509ab2284717613737fc159ab6518f66b7142e9181900360200190a150600390565b6000805b6003821015610897575060005b600381101561088c5760f960020a6027026001836003811061084f57fe5b01826003811061085b57fe5b60208104909101805460f860020a909304601f9092166101000a91820260ff90920219909216179055600101610831565b600190910190610824565b505060088054600080556005805474ff00000000000000000000000000000000000000001916905560078054600160a060020a031916905575ffffffffffffffffffffffffffffffffffffffffffff19169055565b6060600183600381106108fb57fe5b01826003811061090757fe5b602091828204019190069054906101000a900460f860020a02600160f860020a03191660fb60020a600b0214156109595750604080518082019091526001815260fb60020a600b026020820152610a2b565b6001836003811061096657fe5b01826003811061097257fe5b602091828204019190069054906101000a900460f860020a02600160f860020a03191660f860020a604f0214156109c45750604080518082019091526001815260f860020a604f026020820152610a2b565b600183600381106109d157fe5b0182600381106109dd57fe5b602091828204019190069054906101000a900460f860020a02600160f860020a03191660f960020a6027021415610a2b5750604080518082019091526001815260f960020a60270260208201525b92915050565b6000808080805b6003841015610af257600160f860020a0319861660018560038110610a5957fe5b015460f860020a02600160f860020a031916148015610aa45750600160f860020a0319861660018560038110610a8b57fe5b0154610100900460f860020a02600160f860020a031916145b8015610add5750600160f860020a0319861660018560038110610ac357fe5b015462010000900460f860020a02600160f860020a031916145b15610ae757600194505b600190930192610a38565b841515610bdf57600092505b6003831015610bdf57600160f860020a0319861660018460038110610b1f57fe5b602091828204019190069054906101000a900460f860020a02600160f860020a031916148015610b875750600160f860020a0319861660028460038110610b6257fe5b602091828204019190069054906101000a900460f860020a02600160f860020a031916145b8015610bca5750600160f860020a03198616600384818110610ba557fe5b602091828204019190069054906101000a900460f860020a02600160f860020a031916145b15610bd457600194505b600190920191610afe565b841515610cc25760015460f860020a02600160f860020a0319908116908716148015610c245750600254600160f860020a031987811661010090920460f860020a0216145b8015610c4a5750600354600160f860020a03198781166201000090920460f860020a0216145b15610c5457600194505b600154600160f860020a03198781166201000090920460f860020a0216148015610c975750600254600160f860020a031987811661010090920460f860020a0216145b8015610cb8575060035460f860020a02600160f860020a0319908116908716145b15610cc257600194505b60018515151415610db05760fb60020a600b02600160f860020a031987161415610d3a5760045460088054600160a060020a031916600160a060020a03928316179081905560008054918316815260096020526040808220805490930190925580546005549093168152208054919091039055610da3565b60f860020a604f02600160f860020a031987161415610da35760055460088054600160a060020a031916600160a060020a039283161790819055600080549183168152600960205260408082208054909301909255805460045490931681522080549190910390555b610dab610ebc565b610eb4565b6008805475ff00000000000000000000000000000000000000000019167501000000000000000000000000000000000000000000179055600091505b6003821015610e83575060005b6003811015610e785760018260038110610e0f57fe5b018160038110610e1b57fe5b602091828204019190069054906101000a900460f860020a02600160f860020a03191660f960020a6027021415610e70576008805475ff00000000000000000000000000000000000000000019169055610e78565b600101610df9565b600190910190610dec565b6008547501000000000000000000000000000000000000000000900460ff16151560011415610eb457610eb4610ebc565b505050505050565b60048054600160a060020a0319908116909155600580549091169055565b6008546060907501000000000000000000000000000000000000000000900460ff16151560011415610f40575060408051808201909152600481527f647261770000000000000000000000000000000000000000000000000000000060208201526102bd565b600854600160a060020a0316156102bd57600854600160a060020a0316331415610f9e575060408051808201909152600781527f796f752077696e0000000000000000000000000000000000000000000000000060208201526102bd565b5060408051808201909152600881527f796f75206c6f736500000000000000000000000000000000000000000000000060208201526102bd565b60005490565b600454600090600160a060020a03163314156110065750600454600160a060020a03166102bd565b600554600160a060020a03163314156102bd5750600554600160a060020a03166102bd565b3360009081526009602052604090205490565b600454600090600160a060020a031633141561105c575060016102bd565b506000905600a165627a7a72305820083f9c567e5afff51f7bf00e27eb26e4ee6363468dc729b864a37c5647766e430029";
        public Deployment() : base(BYTECODE) { }
    }

    [Function("GetGameStatus", "bool")]
    public class GameStatus : ContractMessage
    {
    }
    [Function("GetBetAmount", "int")]
    public class BetAmount : ContractMessage
    {
    }

    [Function("SetBet")]
    public class SetBet : ContractMessage
    {
        [Parameter("int", "amount", 1)]
        public int betAmount { get; set; }
    }
    [Function("incrementCounter")]
    public class IncreaseCountFunction : ContractMessage
    {

    }
    [Function("GetAddress", "int")]
    public class GetAddressfunction : ContractMessage
    {
    }
    [Function("AddPlayer", "int")]
    public class AddPlayerFunction : ContractMessage
    {
    }

    [Function("SetMark", "bool")]
    public class SetMarkFunction : ContractMessage
    {
        [Parameter("uint", "i")]
        public int Row { get; set; }
        [Parameter("uint", "j")]
        public int Column { get; set; }
    }

    [Function("GetBoradSquare", "string")]
    public class GetBoradSquareFunction : ContractMessage
    {
        [Parameter("uint", "i")]
        public int Row { get; set; }
        [Parameter("uint", "j")]
        public int Column { get; set; }
    }

    [Function("GetTurn", "bool")]
    public class GetTurnFunction : ContractMessage
    {
    }

    [Function("Initialize")]
    public class InitializeFunction : ContractMessage
    {
    }

    [Function("GetWinner", "string")]
    public class GetWinnerFunction : ContractMessage
    {
    }

    [Function("ResetPlayers")]
    public class ResetPlayersFunction : ContractMessage
    {
    }

    [Function("GetBalance", "int")]
    public class GetBalanceFunction : ContractMessage
    {
    }
}

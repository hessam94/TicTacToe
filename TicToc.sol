//solium-disable linebreak-style
pragma solidity ^0.4.25;
contract TicToc
{
int private BetAmount=0;
bytes1[3][3] GameBoard;
address XPlayer;
address OPlayer;
bool GameReady;
address PlayerTurn;
address BetTurn;
address Winner;
bool IsGameStarted;
bool draw;
event TestEvent(bool);
event AddEvent(int);
mapping  (address => int) Balance;
constructor () public 
{

Initialize();
    
}

function Initialize() public 
{
    for (uint i = 0 ; i<3 ; i++)
    {
    for (uint j = 0;j<3;j++)
    {
      GameBoard[i][j]="N";
    }
    }

    draw = false;
    BetAmount =0;
    GameReady = false;
    IsGameStarted = false;
    BetTurn = address(0);
    Winner = address(0);
   
}

function ResetPlayers() public
{
    delete XPlayer;
    delete OPlayer;
}

function AddPlayer() public returns(int)
{

    // address(0) is same as null or empty string
    if (XPlayer == address(0))
    {
    Initialize();
    XPlayer = msg.sender;
    PlayerTurn = msg.sender;
    BetTurn = msg.sender;
    if (Balance[XPlayer] ==0)
    Balance[XPlayer] = 100;
    emit AddEvent(1);
    return 1;
    }
    else if (OPlayer == address(0))
    {
    OPlayer = msg.sender;
    IsGameStarted = true;
    if (Balance[OPlayer] ==0)
    Balance[OPlayer] = 100;
    emit AddEvent(2);
    return 2;
    }
    emit AddEvent(3);
    return 3;
}

function SetBet(int amount) public
{
    if (IsGameStarted ==true)
    {
        require(Balance[msg.sender] >= amount,"balance is not enough");
  if (msg.sender == BetTurn && GameReady == false)
  {
  if (amount == BetAmount)
        GameReady = true;
  else
  {
        BetAmount = amount;
        if (msg.sender == XPlayer)
         BetTurn = OPlayer;
        else if (msg.sender ==OPlayer)
         BetTurn = XPlayer;
  }
  }
     }
}


function GetGameStatus() public view returns (bool)
{
return GameReady;
}
function GetBetAmount() public view returns (int)
{
return BetAmount;
}

function GetAddress() public view returns (address)
{
    if (msg.sender == XPlayer)
    return  XPlayer;
    else if (msg.sender == OPlayer)
    return OPlayer;
}
function GetTurn() public view returns(bool)
{
 if (msg.sender == XPlayer)
 return true;
 return false;
}


function SetMark(uint i, uint j) public  returns (bool)
{
  bytes1 mark ="N";
  address rival;
  if (Winner == address(0))
  {
   if (IsGameStarted == true && PlayerTurn == msg.sender && GameReady == true)
   {
   if (msg.sender== XPlayer)
   {
   mark = "X";
   rival = OPlayer;
   }
   else if (msg.sender == OPlayer)
   {
    mark = "O";
    rival = XPlayer;
   }

   if (mark != "N")
   {
   if ( i < 3 && i >=0 && j < 3 && j>=0)
    if (GameBoard[i][j] == "N")
    {
      GameBoard[i][j] = mark;
      PlayerTurn = rival;
      CheckWinner(mark);
      emit TestEvent(true);   
      return true; 
    }
      else 
      {
      emit TestEvent(false);
      return false;
      }
   }
   }
  }
}

function GetBoradSquare(uint i, uint j) public view returns(string)
{

 if (GameBoard[i][j] =="X")
 return "X";
 else if (GameBoard[i][j] =="O")
 return "O";
 else  if (GameBoard[i][j] =="N")
 return "N";

}

function GetWinner() public view returns (string)
{
  if (draw ==true)
   return "draw"; 
 else if (Winner != address(0))
  {
 if (msg.sender == Winner)
   return "you win";
 else 
   return "you lose";
   
  }

}
function CheckWinner(bytes1 mark) public
{
  bool flag = false;
   for (uint i=0 ;i<3;i++)
    if (GameBoard[i][0] == mark &&  GameBoard[i][1] == mark && GameBoard[i][2] == mark )
    {
      flag = true;
    }

   if (flag ==false)
   {
   for (uint j=0 ;j<3;j++)
   {
     if (GameBoard[0][j] == mark &&  GameBoard[1][j] == mark && GameBoard[2][j] == mark )
       flag = true;
   }
   }

   if (flag == false)
   {
     if (GameBoard[0][0] == mark &&  GameBoard[1][1] == mark && GameBoard[2][2] == mark )
       flag = true;  
     if (GameBoard[0][2] == mark &&  GameBoard[1][1] == mark && GameBoard[2][0] == mark )
       flag = true; 
   }

   if (flag ==true)
   {
     
        if (mark =="X")
         {
    Winner = XPlayer;
    Balance[Winner] += BetAmount;
    Balance[OPlayer] -= BetAmount;
         }
         else if (mark =="O")
            {
    Winner = OPlayer;
    Balance[Winner] += BetAmount;
    Balance[XPlayer] -= BetAmount;
            }
            ResetPlayers();
   }
   else 
   {
     draw = true;
     for (uint ii =0;ii<3;ii++)
       for (uint jj=0;jj<3;jj++)
         if (GameBoard[ii][jj] == "N")
            {
              draw = false;
              break;
            }

            if (draw == true)
            ResetPlayers();


   }


} 


function GetBalance() public view returns(int)
{
return Balance[msg.sender];

}

}
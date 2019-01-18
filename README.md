# TicTacToe
TicTacToe game by c# and Ethereum blockchain
The TicTocToe game is a windows application game developed by C#. It is a multiplayer online game which two players can play.
I used [solidity](https://solidity.readthedocs.io/en/v0.5.2/) to develop the backend part, which is running on Ethereum blockchain and C# for client side application. To connect the client side with Ethereum the [Nethereum](https://github.com/Nethereum) library is used. 
### Test Network
we set a test network to be able to play online. You can use some pre configured test netwroks or set your net ,as well as us. You can find how
to set a test network between two or more computers [here](https://medium.com/mercuryprotocol/how-to-create-your-own-private-ethereum-blockchain-dad6af82fc9f)
The thing that is so impirtant in that you MUST have the same Genesis file on all sides and give enough alloc and have all user files on all sides. (UTC--...)
We got help from [this test chain](https://github.com/Nethereum/Testchains) but you should consider that the files are modified a bit, becaues this test chain is proper for 
single user applications.
### Solidity 
There are a few language to develop programs which can be run on Ethereum blockchain, we used the most famous one [solidity](https://solidity.readthedocs.io/en/v0.5.2/).
you can compile your solidity codes with [Remix website](https://remix.ethereum.org/) or use [Visual studio Code](https://code.visualstudio.com/)

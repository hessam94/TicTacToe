# TicTacToe
TicTacToe game by c# and Ethereum blockchain
The TicTocToe game is a windows application game developed by C#. It is a multiplayer online game which two players can play.
I used [solidity](https://solidity.readthedocs.io/en/v0.5.2/) to develop the backend part, which is running on Ethereum blockchain and C# for client side application. To connect the client side with Ethereum the [Nethereum](https://github.com/Nethereum) library is used. 
### Test Network
we set a test network to be able to play online. You can use some pre configured test netwroks or set your net. We configured our test network. You can find how
to set a test network between two or more computers [here](https://medium.com/mercuryprotocol/how-to-create-your-own-private-ethereum-blockchain-dad6af82fc9f)
.very important point is that you MUST have the same Genesis file on all sides and give enough alloc and have all user files on all sides. (in your keystore file: UTC--...)
We got help from [this test chain](https://github.com/Nethereum/Testchains) but you should consider that the files are modified a bit, becaues this test chain is proper for 
single user applications.
### Solidity 
There are a few language to develop programs which can be run on Ethereum blockchain, we used the most famous one [solidity](https://solidity.readthedocs.io/en/v0.5.2/).
you can compile your solidity codes with [Remix website](https://remix.ethereum.org/) or use [Visual studio Code](https://code.visualstudio.com/)

### Game description
after deploying the game through the application, address of the contract will be added to the list of addresses. so you need to choose which contract you want to play. then both players need to join the game and start to bet, one by one, until both reach to an aggrement on the bet amount. 

<a href="https://www.youtube.com/watch?v=J7PXiK8Ap94
" target="_blank"><img src="http://img.youtube.com/vi/J7PXiK8Ap94/0.jpg" 
alt="IMAGE ALT TEXT HERE" width="240" height="180" border="10" /></a>

### Thanks
I really appreciate [Mr. juan Blanco](https://github.com/juanfranblanco) and [Mr. Dave whiffin](https://github.com/Dave-Whiffin) who created the nethereum library and resolved some issues of this project. This is my first code of Blockchain's World and I know there can be lots of improvments. i will be glad to hear from you guys.  

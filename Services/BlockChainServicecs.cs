using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Threading.Tasks;

namespace Emedicine.Services
{
    public class BlockChainServicecs
    {
        private readonly Web3 _web3;
        private readonly string _contractAddress = "your_contract_address";
        private readonly string _contractABI = "your_contract_ABI";

        public BlockchainService(string infuraUrl, string privateKey)
        {
            var account = new Account(privateKey);
            _web3 = new Web3(account, infuraUrl);
        }

        public async Task RecordTransactionAsync(string transactionHash)
        {
            var contract = _web3.Eth.GetContract(_contractABI, _contractAddress);
            var recordTransactionFunction = contract.GetFunction("recordTransaction");
            await recordTransactionFunction.SendTransactionAsync(_web3.Eth.DefaultAccount, transactionHash);
        }

        public async Task<(string, uint)> GetTransactionAsync(string transactionHash)
        {
            var contract = _web3.Eth.GetContract(_contractABI, _contractAddress);
            var getTransactionFunction = contract.GetFunction("getTransaction");
            var result = await getTransactionFunction.CallAsync<(string, uint)>(transactionHash);
            return result;
        }
    }

}

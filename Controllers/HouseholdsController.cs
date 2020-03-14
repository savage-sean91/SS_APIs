using SS_APIs.Areas.HelpPage.Models;
using SS_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SS_APIs.Controllers
{
    /// <summary>
    /// household controller
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        
        ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// gethousehold method
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int hhId)
        {
            return await db.GetHousehold(hhId);
        }
        /// <summary>
        /// gethouseholdaccounts
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetHouseholdAccounts")]
        public async Task<List<PersonalAccount>> GetHouseholdAccounts(int hhId)
        {
            return await db.GetHouseholdAccounts(hhId);
        }
        /// <summary>
        /// getaccountdetails Method
        /// </summary>
        /// <param name="AcctId"></param>
        /// <returns></returns>
        [Route("GetAccountDetails")]
        public async Task<List<PersonalAccount>> GetAccountsDetails(int AcctId)
        {
            return await db.GetAccountDetails(AcctId);
        }
        /// <summary>
        /// getbudgets method
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<List<Budget>> GetBudgets(int budgetId, int hhId)
        {
            return await db.GetBudgets(budgetId, hhId);
        }
        /// <summary>
        /// getbudgetdetails method
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<List<Budget>> GetBudgetDetails(int budgetId)
        {
            return await db.GetBudgetDetails(budgetId);
        }
        /// <summary>
        /// getbudgetitems
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public async Task<List<BudgetItem>> GetBudgetItems(int budgetId)
        {
            return await db.GetBudgetItems(budgetId);
        }
        /// <summary>
        /// getcategories method
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        [Route("GetCategories")]
        public async Task<List<Category>> GetCategories(int CatId)
        {
            return await db.GetCategories(CatId);
        }
        /// <summary>
        /// getaccounttransactions
        /// </summary>
        /// <param name="acctId"></param>
        /// <returns></returns>
        [Route("GetAccountTransactions")]
        public async Task<List<Transaction>> GetAccountTransactions(int acctId)
        {
            return await db.GetAccountTransactions(acctId);
        }
        /// <summary>
        /// gettransactiondetails
        /// </summary>
        /// <param name="transId"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<List<Transaction>> GetTransactionDetails(int transId)
        {
            return await db.GetTransactionDetails(transId);
        }
        /// <summary>
        /// getbudgetitemdetails
        /// </summary>
        /// <param name="BudgetItemId"></param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<List<BudgetItem>> GetBudgetItemDetails(int BudgetItemId)
        {
            return await db.GetBudgetItemDetails(BudgetItemId);
        }
        /// <summary>
        /// addaccount method
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="hhId"></param>
        /// <param name="Name"></param>
        /// <param name="Balance"></param>
        /// <param name="ReconciledBal"></param>
        /// <param name="createdById"></param>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        [Route("AddAccount")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddAccount(int AccountId, int hhId, string Name, decimal Balance, decimal ReconciledBal, string createdById, bool IsDeleted)
        {
            return Ok(db.AddAccount(AccountId, hhId, Name, Balance, ReconciledBal, createdById, IsDeleted));
        }
        /// <summary>
        /// addbudget method
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="Name"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("AddBudget")]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult AddBudget(int budgetId, string Name, int hhId)
        {
            return Ok(db.AddBudget(budgetId, Name, hhId));
        }
        /// <summary>
        /// addtransaction method
        /// </summary>
        /// <param name="transId"></param>
        /// <param name="AccountId"></param>
        /// <param name="Description"></param>
        /// <param name="Date"></param>
        /// <param name="Amount"></param>
        /// <param name="Type"></param>
        /// <param name="Void"></param>
        /// <param name="catId"></param>
        /// <param name="EnteredById"></param>
        /// <param name="Reconciled"></param>
        /// <param name="ReconciledAmount"></param>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        [Route("AddTransactions")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddTransactions(int transId, int AccountId, string Description, DateTimeOffset Date, decimal Amount, bool Type, bool Void, int catId, string EnteredById, bool Reconciled, decimal ReconciledAmount, bool IsDeleted)
        {
            return Ok(db.AddTransactions(transId, AccountId, Description, Date, Amount, Type, Void, catId, EnteredById, Reconciled, ReconciledAmount, IsDeleted));
        }
     
           
    }
}

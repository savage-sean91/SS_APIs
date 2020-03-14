using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SS_APIs.Areas.HelpPage.Models;

namespace SS_APIs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// ApplicationUser Class
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Method
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    /// <summary>
    /// db class
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// db context method
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// create iden model 
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// gethousehold iden model
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<Household> GetHousehold(int hhId)
        {
            SqlParameter param1 = new SqlParameter("@hhId", hhId);
            return await Database.SqlQuery<Household>("GetHousehold @hhId", param1).FirstOrDefaultAsync();
        }
        /// <summary>
        /// get household accounts
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<PersonalAccount>> GetHouseholdAccounts(int hhId)
        {
            SqlParameter param1 = new SqlParameter("@hhId", hhId);
            return await Database.SqlQuery<PersonalAccount>("GetHouseholdAccounts @hhId", param1).ToListAsync();
        }
        /// <summary>
        /// getaccountdetails 
        /// </summary>
        /// <param name="AcctId"></param>
        /// <returns></returns>
        public async Task<List<PersonalAccount>> GetAccountDetails(int AcctId)
        {
            SqlParameter param1 = new SqlParameter("@AcctId", AcctId);
            return await Database.SqlQuery<PersonalAccount>("GetAccountDetails @AcctId", param1).ToListAsync();
        }
        /// <summary>
        /// getbudgets
        /// </summary>
        /// <param name="BudgetId"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgets(int BudgetId, int hhId)
        {
            SqlParameter param1 = new SqlParameter("@BudgetId", BudgetId);
            SqlParameter param2 = new SqlParameter("@hhId", hhId);
            return await Database.SqlQuery<Budget>("GetBudgets @BudgetId, @hhId", param1, param2).ToListAsync();
        }
        /// <summary>
        /// getbudgetdetails
        /// </summary>
        /// <param name="BudgetId"></param>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgetDetails(int BudgetId)
        {
            SqlParameter param1 = new SqlParameter("@BudgetId", BudgetId);
            return await Database.SqlQuery<Budget>("GetBudgetDetails @BudgetId", param1).ToListAsync();

        }
        /// <summary>
        /// getbudgetitems
        /// </summary>
        /// <param name="BudgetId"></param>
        /// <returns></returns>
        public async Task<List<BudgetItem>> GetBudgetItems(int BudgetId)
        {
            SqlParameter param1 = new SqlParameter("@budgetId", BudgetId);
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @budgetId", param1).ToListAsync();
        }
        /// <summary>
        /// getcategories
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetCategories(int catId)
        {
            SqlParameter param1 = new SqlParameter("@catId", catId);
            return await Database.SqlQuery<Category>("GetCategories @catId", param1).ToListAsync();
        }
        /// <summary>
        /// getaccounttransactions
        /// </summary>
        /// <param name="acctId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetAccountTransactions(int acctId)
        {
            SqlParameter param1 = new SqlParameter("@acctId", acctId);
            return await Database.SqlQuery<Transaction>("GetAccountTransactions @acctId", param1).ToListAsync();
        }
        /// <summary>
        /// gettransactiondetails
        /// </summary>
        /// <param name="transId"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionDetails(int transId)
        {
            SqlParameter param1 = new SqlParameter("transId", transId);
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @transId", param1).ToListAsync();
        }
        /// <summary>
        /// getbudgetitemdetails
        /// </summary>
        /// <param name="BudgetItemId"></param>
        /// <returns></returns>
        public async Task<List<BudgetItem>> GetBudgetItemDetails(int BudgetItemId)
        {
            SqlParameter param1 = new SqlParameter("@BudgetItemId", BudgetItemId);
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @BudgetItemId", param1).ToListAsync();
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
        public int AddAccount(int AccountId, int hhId, string Name, decimal Balance, decimal ReconciledBal, string createdById, bool IsDeleted)
        {
            return Database.ExecuteSqlCommand("AddAccount @AcctId, @hhId, @Name, @Balance, @ReconciledBal, @createdById, @IsDeleted",
            new SqlParameter("@AcctId", AccountId),
            new SqlParameter("@hhId", hhId),
            new SqlParameter("@Name", Name),
            new SqlParameter("@Balance", Balance),
            new SqlParameter("@ReconciledBal", ReconciledBal),
            new SqlParameter("@createdById", createdById),
            new SqlParameter("@IsDeleted", IsDeleted));

        }
        /// <summary>
        /// addbudgetmethod
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="Name"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public int AddBudget(int budgetId, string Name, int hhId)
        {
            return Database.ExecuteSqlCommand("AddBudget @budgetId, @Name, @hhId",
            new SqlParameter("@BudgetId", budgetId),
            new SqlParameter("@Name", Name),
            new SqlParameter("@hhId", hhId));
        }
        /// <summary>
        /// addtransactionmethod
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
        /// <param name="IsDeletd"></param>
        /// <returns></returns>
        public int AddTransactions(int transId, int AccountId, string Description, DateTimeOffset Date, decimal Amount, bool Type, bool Void, int catId, string EnteredById, bool Reconciled, decimal ReconciledAmount, bool IsDeletd)
        {
            return Database.ExecuteSqlCommand("AddTransaction @transId, @AccountId, @Description, @Date, @Amount, @Type, @Void, @CatId, @EnteredById, @Reconciled, @ReconciledAmountm @IsDeleted",
            new SqlParameter("@transId", transId),
            new SqlParameter("@AccountId", AccountId),
            new SqlParameter("@Description", Description),
            new SqlParameter("@Date", Date),
            new SqlParameter("@Amount", Amount),
            new SqlParameter("@Type", Type),
            new SqlParameter("@Void", Void),
            new SqlParameter("@catId", catId),
            new SqlParameter("@EnteredById", EnteredById),
            new SqlParameter("@Reconciled", Reconciled),
            new SqlParameter("@ReconciledAmount", ReconciledAmount),
            new SqlParameter("@IsDeleted", IsDeletd));
        }
    }
}

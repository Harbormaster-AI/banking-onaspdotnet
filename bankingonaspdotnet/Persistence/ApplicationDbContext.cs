using Microsoft.EntityFrameworkCore;

using bankingonaspdotnet.Domain;

namespace bankingonaspdotnet.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<Bank> Banks => Set<Bank>();
public DbSet<Branch> Branchs => Set<Branch>();
public DbSet<ATM> ATMs => Set<ATM>();
public DbSet<Customer> Customers => Set<Customer>();
public DbSet<KycProfile> KycProfiles => Set<KycProfile>();
public DbSet<IdentityDocument> IdentityDocuments => Set<IdentityDocument>();
public DbSet<RiskAssessment> RiskAssessments => Set<RiskAssessment>();
public DbSet<ScreeningResult> ScreeningResults => Set<ScreeningResult>();
public DbSet<BankingProduct> BankingProducts => Set<BankingProduct>();
public DbSet<Account> Accounts => Set<Account>();
public DbSet<AccountStatement> AccountStatements => Set<AccountStatement>();
public DbSet<Transaction> Transactions => Set<Transaction>();
public DbSet<ExternalAccount> ExternalAccounts => Set<ExternalAccount>();
public DbSet<FundsTransfer> FundsTransfers => Set<FundsTransfer>();
public DbSet<StandingInstruction> StandingInstructions => Set<StandingInstruction>();
public DbSet<PaymentCard> PaymentCards => Set<PaymentCard>();
public DbSet<LoanAccount> LoanAccounts => Set<LoanAccount>();
public DbSet<RepaymentSchedule> RepaymentSchedules => Set<RepaymentSchedule>();
public DbSet<LoanPayment> LoanPayments => Set<LoanPayment>();
public DbSet<Collateral> Collaterals => Set<Collateral>();
public DbSet<FeeCharge> FeeCharges => Set<FeeCharge>();
public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();
public DbSet<FXTrade> FXTrades => Set<FXTrade>();
public DbSet<Dispute> Disputes => Set<Dispute>();
public DbSet<Consent> Consents => Set<Consent>();
public DbSet<ThirdPartyProvider> ThirdPartyProviders => Set<ThirdPartyProvider>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Bank has one or more Branches of type Branch
        modelBuilder.Entity<Branch>()
            .HasOne<Bank>()
            .WithMany(parent => parent.Branches)
            .HasForeignKey("BranchesId");

        // Bank has one or more Products of type BankingProduct
        modelBuilder.Entity<BankingProduct>()
            .HasOne<Bank>()
            .WithMany(parent => parent.Products)
            .HasForeignKey("ProductsId");

        // Bank has one or more Customers of type Customer
        modelBuilder.Entity<Customer>()
            .HasOne<Bank>()
            .WithMany(parent => parent.Customers)
            .HasForeignKey("CustomersId");

        // Bank has one or more Accounts of type Account
        modelBuilder.Entity<Account>()
            .HasOne<Bank>()
            .WithMany(parent => parent.Accounts)
            .HasForeignKey("AccountsId");

        // Bank has one or more PaymentCards of type PaymentCard
        modelBuilder.Entity<PaymentCard>()
            .HasOne<Bank>()
            .WithMany(parent => parent.PaymentCards)
            .HasForeignKey("PaymentCardsId");

        // Bank has one or more LoanAccounts of type LoanAccount
        modelBuilder.Entity<LoanAccount>()
            .HasOne<Bank>()
            .WithMany(parent => parent.LoanAccounts)
            .HasForeignKey("LoanAccountsId");

        // Bank has one or more ExchangeRates of type ExchangeRate
        modelBuilder.Entity<ExchangeRate>()
            .HasOne<Bank>()
            .WithMany(parent => parent.ExchangeRates)
            .HasForeignKey("ExchangeRatesId");

        // Bank has one or more Consents of type Consent
        modelBuilder.Entity<Consent>()
            .HasOne<Bank>()
            .WithMany(parent => parent.Consents)
            .HasForeignKey("ConsentsId");

        // Bank has one or more ThirdPartyProviders of type ThirdPartyProvider
        modelBuilder.Entity<ThirdPartyProvider>()
            .HasOne<Bank>()
            .WithMany(parent => parent.ThirdPartyProviders)
            .HasForeignKey("ThirdPartyProvidersId");

        // Branch has one Bank of type Bank
        modelBuilder.Entity<Branch>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");


        // Branch has one or more Accounts of type Account
        modelBuilder.Entity<Account>()
            .HasOne<Branch>()
            .WithMany(parent => parent.Accounts)
            .HasForeignKey("AccountsId");

        // Branch has one or more LoanAccounts of type LoanAccount
        modelBuilder.Entity<LoanAccount>()
            .HasOne<Branch>()
            .WithMany(parent => parent.LoanAccounts)
            .HasForeignKey("LoanAccountsId");

        // Branch has one or more Atms of type ATM
        modelBuilder.Entity<ATM>()
            .HasOne<Branch>()
            .WithMany(parent => parent.Atms)
            .HasForeignKey("AtmsId");

        // ATM has one Branch of type Branch
        modelBuilder.Entity<ATM>()
            .HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey("BranchId");


        // Customer has one Bank of type Bank
        modelBuilder.Entity<Customer>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");


        // Customer has one or more Accounts of type Account
        modelBuilder.Entity<Account>()
            .HasOne<Customer>()
            .WithMany(parent => parent.Accounts)
            .HasForeignKey("AccountsId");

        // Customer has one or more LoanAccounts of type LoanAccount
        modelBuilder.Entity<LoanAccount>()
            .HasOne<Customer>()
            .WithMany(parent => parent.LoanAccounts)
            .HasForeignKey("LoanAccountsId");

        // Customer has one or more PaymentCards of type PaymentCard
        modelBuilder.Entity<PaymentCard>()
            .HasOne<Customer>()
            .WithMany(parent => parent.PaymentCards)
            .HasForeignKey("PaymentCardsId");

        // Customer has one or more ExternalAccounts of type ExternalAccount
        modelBuilder.Entity<ExternalAccount>()
            .HasOne<Customer>()
            .WithMany(parent => parent.ExternalAccounts)
            .HasForeignKey("ExternalAccountsId");

        // Customer has one or more FundsTransfers of type FundsTransfer
        modelBuilder.Entity<FundsTransfer>()
            .HasOne<Customer>()
            .WithMany(parent => parent.FundsTransfers)
            .HasForeignKey("FundsTransfersId");

        // Customer has one or more Disputes of type Dispute
        modelBuilder.Entity<Dispute>()
            .HasOne<Customer>()
            .WithMany(parent => parent.Disputes)
            .HasForeignKey("DisputesId");

        // Customer has one or more KycProfiles of type KycProfile
        modelBuilder.Entity<KycProfile>()
            .HasOne<Customer>()
            .WithMany(parent => parent.KycProfiles)
            .HasForeignKey("KycProfilesId");

        // Customer has one or more Consents of type Consent
        modelBuilder.Entity<Consent>()
            .HasOne<Customer>()
            .WithMany(parent => parent.Consents)
            .HasForeignKey("ConsentsId");

        // KycProfile has one Customer of type Customer
        modelBuilder.Entity<KycProfile>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey("CustomerId");


        // KycProfile has one or more IdentityDocuments of type IdentityDocument
        modelBuilder.Entity<IdentityDocument>()
            .HasOne<KycProfile>()
            .WithMany(parent => parent.IdentityDocuments)
            .HasForeignKey("IdentityDocumentsId");

        // KycProfile has one or more RiskAssessments of type RiskAssessment
        modelBuilder.Entity<RiskAssessment>()
            .HasOne<KycProfile>()
            .WithMany(parent => parent.RiskAssessments)
            .HasForeignKey("RiskAssessmentsId");

        // KycProfile has one or more Screenings of type ScreeningResult
        modelBuilder.Entity<ScreeningResult>()
            .HasOne<KycProfile>()
            .WithMany(parent => parent.Screenings)
            .HasForeignKey("ScreeningsId");

        // IdentityDocument has one KycProfile of type KycProfile
        modelBuilder.Entity<IdentityDocument>()
            .HasOne(x => x.KycProfile)
            .WithMany()
            .HasForeignKey("KycProfileId");


        // RiskAssessment has one KycProfile of type KycProfile
        modelBuilder.Entity<RiskAssessment>()
            .HasOne(x => x.KycProfile)
            .WithMany()
            .HasForeignKey("KycProfileId");


        // ScreeningResult has one KycProfile of type KycProfile
        modelBuilder.Entity<ScreeningResult>()
            .HasOne(x => x.KycProfile)
            .WithMany()
            .HasForeignKey("KycProfileId");


        // BankingProduct has one Bank of type Bank
        modelBuilder.Entity<BankingProduct>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");


        // BankingProduct has one or more Accounts of type Account
        modelBuilder.Entity<Account>()
            .HasOne<BankingProduct>()
            .WithMany(parent => parent.Accounts)
            .HasForeignKey("AccountsId");

        // BankingProduct has one or more LoanAccounts of type LoanAccount
        modelBuilder.Entity<LoanAccount>()
            .HasOne<BankingProduct>()
            .WithMany(parent => parent.LoanAccounts)
            .HasForeignKey("LoanAccountsId");

        // BankingProduct has one or more PaymentCards of type PaymentCard
        modelBuilder.Entity<PaymentCard>()
            .HasOne<BankingProduct>()
            .WithMany(parent => parent.PaymentCards)
            .HasForeignKey("PaymentCardsId");

        // Account has one Bank of type Bank
        modelBuilder.Entity<Account>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");

        // Account has one Branch of type Branch
        modelBuilder.Entity<Account>()
            .HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey("BranchId");

        // Account has one Product of type BankingProduct
        modelBuilder.Entity<Account>()
            .HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey("ProductId");


        // Account has one or more Owners of type Customer
        modelBuilder.Entity<Customer>()
            .HasOne<Account>()
            .WithMany(parent => parent.Owners)
            .HasForeignKey("OwnersId");

        // Account has one or more Transactions of type Transaction
        modelBuilder.Entity<Transaction>()
            .HasOne<Account>()
            .WithMany(parent => parent.Transactions)
            .HasForeignKey("TransactionsId");

        // Account has one or more Statements of type AccountStatement
        modelBuilder.Entity<AccountStatement>()
            .HasOne<Account>()
            .WithMany(parent => parent.Statements)
            .HasForeignKey("StatementsId");

        // Account has one or more StandingInstructions of type StandingInstruction
        modelBuilder.Entity<StandingInstruction>()
            .HasOne<Account>()
            .WithMany(parent => parent.StandingInstructions)
            .HasForeignKey("StandingInstructionsId");

        // Account has one or more FeeCharges of type FeeCharge
        modelBuilder.Entity<FeeCharge>()
            .HasOne<Account>()
            .WithMany(parent => parent.FeeCharges)
            .HasForeignKey("FeeChargesId");

        // AccountStatement has one Account of type Account
        modelBuilder.Entity<AccountStatement>()
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId");


        // Transaction has one Account of type Account
        modelBuilder.Entity<Transaction>()
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId");

        // Transaction has one ExternalCounterparty of type ExternalAccount
        modelBuilder.Entity<Transaction>()
            .HasOne(x => x.ExternalCounterparty)
            .WithMany()
            .HasForeignKey("ExternalCounterpartyId");

        // Transaction has one PaymentCard of type PaymentCard
        modelBuilder.Entity<Transaction>()
            .HasOne(x => x.PaymentCard)
            .WithMany()
            .HasForeignKey("PaymentCardId");

        // Transaction has one FundsTransfer of type FundsTransfer
        modelBuilder.Entity<Transaction>()
            .HasOne(x => x.FundsTransfer)
            .WithMany()
            .HasForeignKey("FundsTransferId");

        // Transaction has one FxTrade of type FXTrade
        modelBuilder.Entity<Transaction>()
            .HasOne(x => x.FxTrade)
            .WithMany()
            .HasForeignKey("FxTradeId");

        // Transaction has one Dispute of type Dispute
        modelBuilder.Entity<Transaction>()
            .HasOne(x => x.Dispute)
            .WithMany()
            .HasForeignKey("DisputeId");


        // ExternalAccount has one Customer of type Customer
        modelBuilder.Entity<ExternalAccount>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey("CustomerId");


        // ExternalAccount has one or more Transactions of type Transaction
        modelBuilder.Entity<Transaction>()
            .HasOne<ExternalAccount>()
            .WithMany(parent => parent.Transactions)
            .HasForeignKey("TransactionsId");

        // FundsTransfer has one SourceAccount of type Account
        modelBuilder.Entity<FundsTransfer>()
            .HasOne(x => x.SourceAccount)
            .WithMany()
            .HasForeignKey("SourceAccountId");

        // FundsTransfer has one DestinationAccount of type Account
        modelBuilder.Entity<FundsTransfer>()
            .HasOne(x => x.DestinationAccount)
            .WithMany()
            .HasForeignKey("DestinationAccountId");

        // FundsTransfer has one ExternalBeneficiary of type ExternalAccount
        modelBuilder.Entity<FundsTransfer>()
            .HasOne(x => x.ExternalBeneficiary)
            .WithMany()
            .HasForeignKey("ExternalBeneficiaryId");

        // FundsTransfer has one InitiatedBy of type Customer
        modelBuilder.Entity<FundsTransfer>()
            .HasOne(x => x.InitiatedBy)
            .WithMany()
            .HasForeignKey("InitiatedById");


        // FundsTransfer has one or more Transactions of type Transaction
        modelBuilder.Entity<Transaction>()
            .HasOne<FundsTransfer>()
            .WithMany(parent => parent.Transactions)
            .HasForeignKey("TransactionsId");

        // StandingInstruction has one Account of type Account
        modelBuilder.Entity<StandingInstruction>()
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId");

        // StandingInstruction has one Beneficiary of type ExternalAccount
        modelBuilder.Entity<StandingInstruction>()
            .HasOne(x => x.Beneficiary)
            .WithMany()
            .HasForeignKey("BeneficiaryId");


        // PaymentCard has one Bank of type Bank
        modelBuilder.Entity<PaymentCard>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");

        // PaymentCard has one Account of type Account
        modelBuilder.Entity<PaymentCard>()
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId");

        // PaymentCard has one Customer of type Customer
        modelBuilder.Entity<PaymentCard>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey("CustomerId");


        // PaymentCard has one or more Transactions of type Transaction
        modelBuilder.Entity<Transaction>()
            .HasOne<PaymentCard>()
            .WithMany(parent => parent.Transactions)
            .HasForeignKey("TransactionsId");

        // LoanAccount has one Bank of type Bank
        modelBuilder.Entity<LoanAccount>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");

        // LoanAccount has one Branch of type Branch
        modelBuilder.Entity<LoanAccount>()
            .HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey("BranchId");

        // LoanAccount has one Product of type BankingProduct
        modelBuilder.Entity<LoanAccount>()
            .HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey("ProductId");


        // LoanAccount has one or more Borrowers of type Customer
        modelBuilder.Entity<Customer>()
            .HasOne<LoanAccount>()
            .WithMany(parent => parent.Borrowers)
            .HasForeignKey("BorrowersId");

        // LoanAccount has one or more RepaymentSchedule of type RepaymentSchedule
        modelBuilder.Entity<RepaymentSchedule>()
            .HasOne<LoanAccount>()
            .WithMany(parent => parent.RepaymentSchedule)
            .HasForeignKey("RepaymentScheduleId");

        // LoanAccount has one or more Payments of type LoanPayment
        modelBuilder.Entity<LoanPayment>()
            .HasOne<LoanAccount>()
            .WithMany(parent => parent.Payments)
            .HasForeignKey("PaymentsId");

        // LoanAccount has one or more Collateral of type Collateral
        modelBuilder.Entity<Collateral>()
            .HasOne<LoanAccount>()
            .WithMany(parent => parent.Collateral)
            .HasForeignKey("CollateralId");

        // LoanAccount has one or more FeeCharges of type FeeCharge
        modelBuilder.Entity<FeeCharge>()
            .HasOne<LoanAccount>()
            .WithMany(parent => parent.FeeCharges)
            .HasForeignKey("FeeChargesId");

        // RepaymentSchedule has one LoanAccount of type LoanAccount
        modelBuilder.Entity<RepaymentSchedule>()
            .HasOne(x => x.LoanAccount)
            .WithMany()
            .HasForeignKey("LoanAccountId");

        // RepaymentSchedule has one Payment of type LoanPayment
        modelBuilder.Entity<RepaymentSchedule>()
            .HasOne(x => x.Payment)
            .WithMany()
            .HasForeignKey("PaymentId");


        // LoanPayment has one LoanAccount of type LoanAccount
        modelBuilder.Entity<LoanPayment>()
            .HasOne(x => x.LoanAccount)
            .WithMany()
            .HasForeignKey("LoanAccountId");

        // LoanPayment has one Transaction of type Transaction
        modelBuilder.Entity<LoanPayment>()
            .HasOne(x => x.Transaction)
            .WithMany()
            .HasForeignKey("TransactionId");


        // Collateral has one LoanAccount of type LoanAccount
        modelBuilder.Entity<Collateral>()
            .HasOne(x => x.LoanAccount)
            .WithMany()
            .HasForeignKey("LoanAccountId");


        // FeeCharge has one Account of type Account
        modelBuilder.Entity<FeeCharge>()
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId");

        // FeeCharge has one LoanAccount of type LoanAccount
        modelBuilder.Entity<FeeCharge>()
            .HasOne(x => x.LoanAccount)
            .WithMany()
            .HasForeignKey("LoanAccountId");


        // ExchangeRate has one Bank of type Bank
        modelBuilder.Entity<ExchangeRate>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");


        // ExchangeRate has one or more FxTrades of type FXTrade
        modelBuilder.Entity<FXTrade>()
            .HasOne<ExchangeRate>()
            .WithMany(parent => parent.FxTrades)
            .HasForeignKey("FxTradesId");

        // FXTrade has one Customer of type Customer
        modelBuilder.Entity<FXTrade>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey("CustomerId");

        // FXTrade has one Bank of type Bank
        modelBuilder.Entity<FXTrade>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");

        // FXTrade has one ExchangeRate of type ExchangeRate
        modelBuilder.Entity<FXTrade>()
            .HasOne(x => x.ExchangeRate)
            .WithMany()
            .HasForeignKey("ExchangeRateId");

        // FXTrade has one SourceAccount of type Account
        modelBuilder.Entity<FXTrade>()
            .HasOne(x => x.SourceAccount)
            .WithMany()
            .HasForeignKey("SourceAccountId");

        // FXTrade has one DestinationAccount of type Account
        modelBuilder.Entity<FXTrade>()
            .HasOne(x => x.DestinationAccount)
            .WithMany()
            .HasForeignKey("DestinationAccountId");

        // FXTrade has one Transaction of type Transaction
        modelBuilder.Entity<FXTrade>()
            .HasOne(x => x.Transaction)
            .WithMany()
            .HasForeignKey("TransactionId");


        // Dispute has one Transaction of type Transaction
        modelBuilder.Entity<Dispute>()
            .HasOne(x => x.Transaction)
            .WithMany()
            .HasForeignKey("TransactionId");

        // Dispute has one Customer of type Customer
        modelBuilder.Entity<Dispute>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey("CustomerId");

        // Dispute has one Account of type Account
        modelBuilder.Entity<Dispute>()
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId");

        // Dispute has one PaymentCard of type PaymentCard
        modelBuilder.Entity<Dispute>()
            .HasOne(x => x.PaymentCard)
            .WithMany()
            .HasForeignKey("PaymentCardId");


        // Consent has one Customer of type Customer
        modelBuilder.Entity<Consent>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey("CustomerId");

        // Consent has one Bank of type Bank
        modelBuilder.Entity<Consent>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");

        // Consent has one ThirdPartyProvider of type ThirdPartyProvider
        modelBuilder.Entity<Consent>()
            .HasOne(x => x.ThirdPartyProvider)
            .WithMany()
            .HasForeignKey("ThirdPartyProviderId");


        // Consent has one or more AuthorizedAccounts of type Account
        modelBuilder.Entity<Account>()
            .HasOne<Consent>()
            .WithMany(parent => parent.AuthorizedAccounts)
            .HasForeignKey("AuthorizedAccountsId");

        // ThirdPartyProvider has one Bank of type Bank
        modelBuilder.Entity<ThirdPartyProvider>()
            .HasOne(x => x.Bank)
            .WithMany()
            .HasForeignKey("BankId");


        // ThirdPartyProvider has one or more Consents of type Consent
        modelBuilder.Entity<Consent>()
            .HasOne<ThirdPartyProvider>()
            .WithMany(parent => parent.Consents)
            .HasForeignKey("ConsentsId");

    }
}

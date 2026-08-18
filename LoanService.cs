using Microsoft.VisualBasic;
using System.Runtime.ConstrainedExecution;

namespace PracticingObjectCalisthenics;

public class LoanService
{
    #region Constructor
    private readonly DebtRepository _debtRepository;
    private readonly NotificationService _notificationService;
    private readonly ILogger<LoanService> _logger;

    public LoanService(DebtRepository debtRepository, NotificationService notificationService, ILogger<LoanService> logger)
    {
        _debtRepository = debtRepository;
        _notificationService = notificationService;
        _logger = logger;
    }
    #endregion

    #region 1. One Level of Indentation per Method
    // 1. Before
    public async Task ApproveAsync(LoanApplication application)
    {
        if (application.Status == LoanStatus.Pending)
        {
            if (application.Customer.IsActive)
            {
                if (application.Customer.CreditScore >= 700)
                {
                    var debt = await _debtRepository.GetOutstandingDebtAsync(application.Customer.Id);

                    if (debt == 0)
                    {
                        application.Approve();

                        await _debtRepository.SaveAsync(application);
                        await _notificationService.SendApprovalEmailAsync(application.Customer.Email);
                    }
                }
            }
        }
    }

    // 1. After
    public async Task ApproveAsyncBetter(LoanApplication application)
    {
        var canBeApproved = await CanBeApproved(application);

        if (!canBeApproved)
            return;

        await ApproveLoan(application);
    }

    private async Task<bool> CanBeApproved(LoanApplication application) 
    { 
        if (application.Status != LoanStatus.Pending) 
            return false; 
        
        if (!application.Customer.IsActive) 
            return false; 

        if (application.Customer.CreditScore < 700) 
            return false; 

        var debt = await _debtRepository.GetOutstandingDebtAsync(application.Customer.Id); 
        
        return debt == 0;
    }

    private async Task ApproveLoan(LoanApplication application) 
    { 
        application.Approve(); 
        
        await _debtRepository.SaveAsync(application); 
        
        await _notificationService.SendApprovalEmailAsync(application.Customer.Email); 
    }
    #endregion

    #region 2. Don't Use the ELSE Keyword
    // 2. Before
    public async Task Cancel(LoanApplication application)
    {
        if (application.Status == LoanStatus.Pending)
        {
            application.Cancel();

            await _debtRepository.SaveAsync(application);

            await _notificationService.SendCancellationEmailAsync(application.Customer.Email);
        }
        else
        {
            _logger.LogWarning("Loan {LoanId} cannot be cancelled because it is {Status}.",
                application.Id,
                application.Status);
        }
    }

    // 2. After
    public async Task CancelBetter(LoanApplication application)
    {
        if (application.Status != LoanStatus.Pending)
        {
            _logger.LogWarning("Loan {LoanId} cannot be cancelled because it is {Status}.",
                application.Id,
                application.Status);

            return;
        }

        application.Cancel();

        await _debtRepository.SaveAsync(application);

        await _notificationService.SendCancellationEmailAsync(application.Customer.Email);
    }
    #endregion

    #region 3. Wrap All Primitives and Strings
    // 3. Before
    public void ProcessApplication()
    {
        var application = new LoanApplication(
            amount: -5000, 
            interestRate: -15, 
            installments: []
        );
    }

    // 3. After
    public void ProcessApplicationBetter()
    {
        var application = new LoanApplicationBetter(
            new Money(50_000), 
            new InterestRate(1.25m),
            new InstallmentCount(48)
        );
    }
    #endregion

    #region 4. First-Class Collections
    public void CreateInstallment()
    {
        var application = new LoanApplication(
            amount: -5000,
            interestRate: -15,
            installments: []
        );

        application.Installments.Clear();

        application.Installments.Add(new Installment(1, 10, new DateOnly(2026, 9, 10)));

        application.Installments.RemoveAt(2);
    }

    public void CreateInstallmentBetter()
    {
        var application = new LoanApplicationObject();

        var installment = new Installment(
            number: 1,
            amount: 1_250.00m,
            dueDate: new DateOnly(2026, 9, 10));

        application.AddInstallment(installment);
    }
    #endregion

    #region 5. One Dot per Line
    public void LogLoanApproval(LoanApplication application)
    {
        _logger.LogInformation("Loan {LoanId} approved for customer from {City}.",
            application.Id,
            application.Customer.Address.City.Name);
    }

    public void LogLoanApprovalBetter(LoanApplication application)
    {
        _logger.LogInformation("Loan {LoanId} approved for customer from {City}.",
            application.Id,
            application.CustomerBetter.CityName);
    }
    #endregion

    #region 6. Don't Abbreviate
    public void CalcTot()
    {
        var usr = GetUsr();
        var ords = usr.Orders;
        var tot = 0;

        foreach (var ord in ords)
        {
            var amt = ord.Amount;
            tot += amt;
        }
    }

    public void CalculateTotal()
    {
        var user = GetUser();
        var orders = user.Orders;
        var total = 0;

        foreach (var order in orders)
        {
            var amount = order.Amount;
            total += amount;
        }
    }

    private User GetUsr()
    {
        throw new NotImplementedException();
    }

    private User GetUser()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region 7. Keep All Entities Small
    /*
     * Entities: 
        CustomerOrderBetter
        OrderValidator
        OrderNotificationService
        OrderRepository
    */
    #endregion

    #region 8. No Classes with More Than Two Instance Variables
    /* Entities:
         * Student
         * StudentBetter
         * PersonalInformation
         * ContactInformation
         * Address
         * */
    #endregion

    #region 9. No Getters/Setters/Properties
    public void CalcularePoints()
    {
        var account = new LoyaltyAccount();

        account.Points += 100;

        account.Points = -500;
    }

    public void CalcularePointsBetter()
    {
        var account = new LoyaltyAccountBetter();

        account.EarnPoints(100);

        account.RedeemPoints(50);

        //It doesn't compile now
        //account.Points += 100;
    }
    #endregion
}
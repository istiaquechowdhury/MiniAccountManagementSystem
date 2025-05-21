# MiniAccountManagementSystem

## Project Setup Guideline

1. **Clone the Repository**  
   `https://github.com/istiaquechowdhury/MiniAccountManagementSystem`

2. **Create a Database in SQL Server Management Studio (SSMS)**  
   - Open SSMS.  
   - Create a new database and name it **MiniAccountsDB** .

3. **Execute the Database Script**  
   - Open the file **/SqlScripts/DatabaseSetup.sql**.  
   - Copy its entire SQL content.  
   - In SSMS, select the **MiniAccountsDB** database, paste the script into a new query window, and **Execute**.

4. **Run the EF-Core Migration for ASP.NET Identity**  
   - In Visual Studio’s **Package Manager Console** (or any terminal), run:  
   
     "dotnet ef database update --project MiniAccountManagementSystem.DataAccess  --startup-project MiniAccountManagementSystem  --context ApplicationIdentityDbContext -- --output-dir ApplicationDB/Migrations"
   
   - This command adds the seven built-in ASP.NET Identity tables to the same database.

That’s it—run the project and navigate using the navigation bar on the first page.

---

### Roles

| Role | Username | Password | Can Access |
|------|----------|----------|------------|
| **Admin** | `admin@gmail.com` | `Pass@123` | **AddUser**, **AddRole**, **AssignAccess**, **AssignUserRole** |
| **Accountant** | `accountant@gmail.com` | `Pass@123` | **ChartOfAccounts**, **VoucherList** |
| **Viewer** | Any self-registered user | *(chosen at signup)* | VoucherList |

Newly registered users are automatically placed in the **Viewer** role.

### 1. Landing Page  
![Landing Page](ScreenShots/01-LandingPage.png)

### 2. Login As Admin  
![Login As Admin](ScreenShots/02-LoginAsAdmin.png)

### 3. Admin's View  
![Admin's View](ScreenShots/03-AdminsView.png)

### 4. Add Role Validation  
![Add Role Validation](ScreenShots/04-AddRoleValidation.png)

### 5. Adding Cashier Role  
![Adding Cashier Role](ScreenShots/05-AddingCashierRole.png)

### 6. Added Cashier Role Toaster Alert  
![Added Cashier Role Toaster Alert](ScreenShots/06-AddedCashierRoleToasterAlert.png)

### 7. Add User Validation  
![Add User Validation](ScreenShots/07-AddUserValidation.png)

### 8. Adding New User  
![Adding New User](ScreenShots/08-addingnewuser.png)

### 9. New User Added Toaster Alert  
![New User Added Toaster Alert](ScreenShots/09-NewUserAddedToasteralert.png)

### 10. Assigning Access  
![Assigning Access](ScreenShots/10-AssigningAccess.png)

### 11. Assigning Access (Step 2)  
![Assigning Access (Step 2)](ScreenShots/11-AssigningAccess2.png)

### 12. Access Added  
![Access Added](ScreenShots/12-addedAccess.png)

### 13. Assigned Access Toaster  
![Assigned Access Toaster](ScreenShots/13-addedAssignedAccessToaster.png)

### 14. Assigning Role To User  
![Assigning Role To User](ScreenShots/14AssigningRoleToUser.png)

### 15. Assigning Role To User (Step 2)  
![Assigning Role To User (Step 2)](ScreenShots/15AssigningRoleToUser2.png)

### 16. Assigned Role To User Successfully Toaster  
![Assigned Role To User Successfully Toaster](ScreenShots/16-AssignedRoleToUserSuccessfullyToaster.png)

### 17. Login As Accountant  
![Login As Accountant](ScreenShots/17-loginAsAccountant.png)

### 18. View Of Accountant  
![View Of Accountant](ScreenShots/18-ViewOfAccountant.png)

### 19. Create a Voucher  
![Create a Voucher](ScreenShots/19-Let%20us%20create%20a%20vouchar.png)

### 20. Voucher Create Page  
![Voucher Create Page](ScreenShots/20-VoucharCreatePage.png)

### 21. Debit and Credit Must Be Equal Validation  
![Debit and Credit Must Be Equal Validation](ScreenShots/21-ValidationDebitandCreditmustbeEqual.png)

### 22. After Creating Voucher  
![After Creating Voucher](ScreenShots/22-after%20creating%20voucher%20.png)

### 23. View Voucher Details  
![View Voucher Details](ScreenShots/23-afterclickingviewthedetailsIsShowing.png)

### 24. Edit Voucher Page  
![Edit Voucher Page](ScreenShots/24-after%20clicking%20edit.png)

### 25. Debit and Credit Not Equal Error  
![Debit and Credit Not Equal Error](ScreenShots/25-cannot%20update%20if%20debit%20and%20credit%20are%20not%20equal.png)

### 26. Update More Entries  
![Update More Entries](ScreenShots/26-we%20can%20update%20more%20entries.png)

### 27. Two More Entries Added  
![Two More Entries Added](ScreenShots/27-two%20more%20entries%20added.png)

### 28. Delete Confirmation  
![Delete Confirmation](ScreenShots/28-by%20pressing%20the%20delete%20button%20this%20shows.png)

### 29. Entry Deleted  
![Entry Deleted](ScreenShots/29-after%20pressing%20ok%20it%20is%20no%20more.png)

### 30. Chart of Account Page  
![Chart of Account Page](ScreenShots/30-This%20is%20Char%20of%20Account%20Page.png)

### 31. Creating Chart of Account  
![Creating Chart of Account](ScreenShots/31-Creating%20Chart%20of%20account.png)

### 32. Chart of Account Created  
![Chart of Account Created](ScreenShots/32-CharOfAccountCreated.png)

### 33. Editing Chart of Account  
![Editing Chart of Account](ScreenShots/33-EditingChartOfAccount.png)

### 34. Chart of Account Edited Successfully  
![Chart of Account Edited Successfully](ScreenShots/34-ChartOfAccount%20Edited%20Successfully.png)

### 35. Delete Chart of Account  
![Delete Chart of Account](ScreenShots/35-after%20pressing%20delete.png)

### 36. Chart of Accounts Deleted  
![Chart of Accounts Deleted](ScreenShots/36-the%20charof%20accounts%20deleted.png)

### 37. Registering As Viewer  
![Registering As Viewer](ScreenShots/37-RegisteringAs%20a%20viewer.png)

### 38. Login As Viewer  
![Login As Viewer](ScreenShots/38-Login%20As%20a%20viewer.png)

### 39. Viewer Login View  
![Viewer Login View](ScreenShots/39-this%20is%20the%20login%20view%20for%20Viewer.png)

### 40. Viewer Can Only See Voucher List  
![Viewer Can Only See Voucher List](ScreenShots/40-Can%20see%20only%20the%20vouchar%20list%20.png)

### 41. Viewer Cannot Create Voucher  
![Viewer Cannot Create Voucher](ScreenShots/41-ViwerCannot%20create.png)



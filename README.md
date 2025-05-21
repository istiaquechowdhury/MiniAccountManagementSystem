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

## 📸 Project Screenshots

### 🔐 Login & User Roles
![01 - Landing Page](ScreenShots/01-LandingPage.png)
![02 - Login As Admin](ScreenShots/02-LoginAsAdmin.png)
![03 - Admin's View](ScreenShots/03-AdminsView.png)
![04 - Add Role Validation](ScreenShots/04-AddRoleValidation.png)
![05 - Adding Cashier Role](ScreenShots/05-AddingCashierRole.png)
![06 - Cashier Role Added (Toast)](ScreenShots/06-AddedCashierRoleToasterAlert.png)

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

1. Landing Page


2. Login As Admin

3. Admin's View

4. Add Role Validation

5. Adding Cashier Role

6. Added Cashier Role (Toaster Alert)

7. Add User Validation

8. Adding New User

9. New User Added (Toaster Alert)

10. Assigning Access (Step 1)

11. Assigning Access (Step 2)

12. Added Access

13. Assigned Access (Toaster Alert)

14. Assigning Role To User (Step 1)

15. Assigning Role To User (Step 2)

16. Assigned Role Successfully (Toaster Alert)

17. Login As Accountant

18. Accountant's View

19. Create a Voucher
![Create Voucher](ScreenShots/19-Let us create a vouchar.png)

20. Voucher Create Page

21. Validation: Debit and Credit Must Be Equal

22. After Creating Voucher
![Created Voucher](ScreenShots/22-after creating voucher .png)

23. Viewing Voucher Details

24. Editing Voucher
![Edit Voucher](ScreenShots/24-after clicking edit.png)

25. Error: Debit and Credit Not Equal
![Error](ScreenShots/25-cannot update if debit and credit are not equal.png)

26. Update More Entries
![Update Entries](ScreenShots/26-we can update more entries.png)

27. Two More Entries Added
![More Entries](ScreenShots/27-two more entries added.png)

28. Delete Confirmation
![Delete Confirmation](ScreenShots/28-by pressing the delete button this shows.png)

29. After Deletion
![After Deletion](ScreenShots/29-after pressing ok it is no more.png)

30. Chart of Accounts Page
![Chart Page](ScreenShots/30-This is Char of Account Page.png)

31. Creating Chart of Account
![Creating Chart](ScreenShots/31-Creating Chart of account.png)

32. Chart of Account Created

33. Editing Chart of Account

34. Chart of Account Edited Successfully
![Edited Chart](ScreenShots/34-ChartOfAccount Edited Successfully.png)

35. Pressing Delete on Chart
![Delete Chart](ScreenShots/35-after pressing delete.png)

36. Chart of Account Deleted
![Chart Deleted](ScreenShots/36-the charof accounts deleted.png)

37. Registering As Viewer
![Register Viewer](ScreenShots/37-RegisteringAs a viewer.png)

38. Login As Viewer
![Login Viewer](ScreenShots/38-Login As a viewer.png)

39. Viewer Dashboard
![Viewer Dashboard](ScreenShots/39-this is the login view for Viewer.png)

40. Viewer Can See Voucher List Only
![Viewer View](ScreenShots/40-Can see only the vouchar list .png)

41. Viewer Cannot Create
![Cannot Create](ScreenShots/41-ViwerCannot create.png)





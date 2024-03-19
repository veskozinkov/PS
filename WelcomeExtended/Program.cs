using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User
                {
                    Names = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };

                UserViewModel viewModel = new UserViewModel(user);
                UserView view = new UserView(viewModel);

                view.DisplayBasic();
                view.DisplayError();
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);

                /*var log = new ActionOnError(Delegates.FileLog);
                log(e.Message);*/
            }
            finally
            {
                Console.WriteLine("Executed in any case!");

                /*var printAllLogMessages = new PrintAllLogMessages(Delegates.Print);
                printAllLogMessages();*/

                /*var printLogMessage = new PrintLogMesssage(Delegates.Print);
                printLogMessage(0);*/

                /*var deleteLogMessage = new DeleteLogMessage(Delegates.Delete);
                deleteLogMessage(0);*/
            }
        }
    }
}

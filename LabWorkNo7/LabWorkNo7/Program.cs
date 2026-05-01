using LabWorkNo7.Services;
using LabWorkNo7.UI;

var storage = new BookRepository();
var notifier = new ConsoleNotificationSender();
var validator = new BookValidator();

var menu = new LibraryMenu(storage, notifier, validator);
menu.Show();

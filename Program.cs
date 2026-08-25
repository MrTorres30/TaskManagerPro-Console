using TaskManagerProC.Services;
using TaskManagerProC.UI;
var auditService = new AuditService();
var taskManager  = new TaskManager(auditService);
var ui           = new ConsoleInterface(taskManager, auditService);
ui.Run();
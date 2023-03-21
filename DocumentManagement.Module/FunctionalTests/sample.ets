;#DropDB DocumentManagementEasyTest

#Application DocumentManagementWin
#Application DocumentManagementBlazor

*FillForm
 User Name = Admin
*Action Log In

#IfDef DocumentManagementWin

*Action About...
 
*Action OK

#EndIf

#IfDef DocumentManagementBlazor
*Action Navigation(My Details)
#EndIf

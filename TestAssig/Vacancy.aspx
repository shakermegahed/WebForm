<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vacancy.aspx.cs" Inherits="TestAssig.Vacancy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
   
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Vacancy Management</h3>
                    </div>
                    <div class="panel-body">
                        <div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
                            Done, changes has been saved successfully!
                        </div>
                        <div class="alert alert-danger" id="alertFaild" runat="server" visible="false">
                            Error, Please try again later!
                        </div>
                        <div class=" form">
                            <div class="cmxform form-horizontal tasi-form" id="signupForm">

                                <div class="form-group">
                                    <label class="control-label col-lg-2">Employee *</label>
                                    <div class="col-lg-8">
                                        <input class=" form-control" placeholder="employee name" required="required" id="txtemp" runat="server" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-2">Title *</label>
                                    <div class="col-lg-8">
                                        <input class=" form-control" placeholder="title" required="required" id="txtTitle" runat="server" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-2">Department *</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" required="required" class="form-control" DataTextField="name" DataValueField="id" DataSourceID="ObjectDataSource1">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Load" TypeName="DAL.DepartmentManagement"></asp:ObjectDataSource>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-2">Date From *</label>
                                    <div class="col-lg-8">

                                         <input type="date" id="txtFrom" runat="server" name="txtFrom" />
                                       
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-2">Date TO *</label>
                                    <div class="col-lg-8">
                            
                                     
                                         <asp:TextBox ID="txtTo" type="date" runat="server" AutoPostBack="true" OnTextChanged="txtTo_TextChanged"  ></asp:TextBox>
                                        </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-2">Returning</label>
                                    <div class="col-lg-8">
                                        <input class=" form-control"  id="txtReturning" runat="server" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-lg-2">Total Number</label>
                                    <div class="col-lg-8">
                                        <input class=" form-control" readonly id="txtTotalNumber" runat="server" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lastname" class="control-label col-lg-2">Notes *</label>
                                    <div class="col-lg-8">
                                        <textarea id="edContent" style="width: 50%" rows="5" cols="80" runat="server">
                                        </textarea>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-lg-offset-2 col-lg-10">
                                        <asp:Button ID="btnSubmit" class="btn btn-success" OnClick="btnSubmit_Click" runat="server" Text="Save"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- .form -->

                    </div>
                    <!-- panel-body -->
                </div>
                <!-- panel -->
            </div>
            <!-- col -->

        </div>
         <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap-dropdownhover.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.counterup.min.js"></script>
        <script src="js/jquery.isotope.min.js"></script>
        <script src="js/jquery.magnific-popup.min.js"></script>
       
        <script src="js/jquery.plugin.min.js"></script>
   

        <script>  
$(function ()  
{  
    $('#txtTo').datepicker(  
    {  
        dateFormat: 'dd/mm/yy',  
        changeMonth: true,  
        changeYear: true,  
        yearRange: '1950:2100'  
    });  
})  
</script> 
    </form>
</body>
</html>

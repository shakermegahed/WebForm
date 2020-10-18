<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestAssig._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Vacancies Listing
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <table width="100%">
                        <tr>
                            <td align="center" style="height: 55px;">
                                <a href="Vacancy.aspx" class="btn btn-success">Add New Vacancy</a>
                            </td>
                        </tr>
                    </table>
      
                    <div class="table-responsive">
                        <table id="datatable" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Date</th>
                                    <th>Employee Name</th>
                                    <th>Department</th>
                                    <th>From</th>
                                    <th>To</th>
                                    <th>Option</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="dlSections" runat="server" DataSourceID="ODSvacancies" >
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("SubmissionDate", "{0:dd/M/yyyy}")%>
                                            </td>
                                            <td><%# Eval("EmployeeName") %></td>
                                            <td><%# Eval("name") %></td>
                                            <td>
                                                <%#Eval("VacationDateFrom", "{0:dd/M/yyyy}")%>
                                            </td>
                                            <td>
                                                <%#Eval("VacationDateTo", "{0:dd/M/yyyy}")%>
                                            </td>
  
                                            <td>
                                                <a class="btn btn-success tooltips" title="Edit" href='<%# "deatilspage.aspx?ID=" + Eval("VacancyId") %>'>Details</a>
                                               
                                                </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <asp:ObjectDataSource ID="ODSvacancies" runat="server" SelectMethod="Load" TypeName="DAL.VacationManagement">
                 
                        </asp:ObjectDataSource>
                    </div>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>

</asp:Content>

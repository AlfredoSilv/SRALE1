
<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <meta name="viewport" content="width=device-width" />
        <title>@ViewBag.Title - Sistema de Registro de Análises Laboratoriais em ETAs</title>
        <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
       
        <link rel="stylesheet" href="~/Content/themes/base/jquery-ui.css">
        <script src="~/Scripts/jquery-1.12.4.js"></script> @*https://code.jquery.com/jquery-1.12.4.js*@
        <script src="~/Scripts/jquery-ui.js"></script> @*https://code.jquery.com/ui/1.12.1/jquery-ui.js*@

        <script>
            $(function () {
                $("#datepicker").datepicker({ dateFormat: 'dd/mm/yyyy' });
            });
        </script>
       
        @Styles.Render("~/Content/bootstrapcss/css")
        @Styles.Render("~/Content/bootstrap/duallistbox/css")
        @Styles.Render("~/Content/css")
        @Styles.Render("~/Content/themes/base/css")
        @Styles.Render("~/Content/multiselectui/css")
        @RenderSection("styles", required:=False)
        @RenderBody()
        @Scripts.Render("~/bundles/modernizr")  
                 
    </head>
    <body>
        <div id="Container" class="container-fluid fill">
            <header id="header" class="row cabecalho">
                <h3 style="text-align:center; font-family:Arial;"><b>SISTEMA DE REGISTRO DE ANÁLISES LABORATORIAIS EM ETA</b></h3>
                <p Class="nav navbar-text navbar-left">Bem vindo, @User.Identity.Name!</p>
            </header>
        </div>
        <div id="body" class="row body-content">
            <p>
                Data: <input type="text" id="datepicker" />
                Coordenação:
                @* Passando o Nome da ViewBag *@
                @Html.DropDownList("ElementId", String.Empty)
            </p>
            <input type="submit" value="Enviar" class="btn btn-default" />           
        </div>
        <hr />
        <div id="footer" class="row fill">
            <footer id="rodape" class="row fill">
                <p>&copy; @DateTime.Now.Year - Compesa - GPA</p>
            </footer>
        </div>        
        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/bootstrap")
    </body>
</html>


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
        <script src="~/Scripts/jquery-ui-1.12.1.js"></script>
        <script src="~/Scripts/jquery-ui.js"></script>
        <script>
          $( function() {
              $("#txtData").datepicker();
          } );
        </script>
        @Styles.Render("~/Content/bootstrapcss/css")
        @Styles.Render("~/Content/bootstrap/duallistbox/css")
        @Styles.Render("~/Content/css")
        @Styles.Render("~/Content/themes/base/css")
        @Styles.Render("~/Content/multiselectui/css")
        @RenderSection("styles", required:=False)
        @Scripts.Render("~/bundles/modernizr")  
                 
    </head>
    <body>
        <section id="Container" class="container-fluid fill">
            <header id="header" class="row cabecalho">
                <h1>SISTEMA DE REGISTRO DE ANÁLISES LABORATORIAIS EM ETA</h1>
                <p Class="nav navbar-text navbar-left">Bem vindo, @User.Identity.Name!</p>
            </header>
        </section>
        <section id="body" class="row body-content">
            <p>Data: <input type="text" id="txtData" /></p>
            @ModelType SRALE.SRALE.Models.clsCoordDdlViewModel
            @Using Html.BeginForm()
                @Html.DropDownListFor(Function(x) x.SelectedItem, Model.Items)
                @<input type="submit" value="OK" />
            End Using
        </section>
        <section id="footer" class="row fill">
            <footer id="rodape" class="row fill">
                <p>&copy; @DateTime.Now.Year - Compesa - GPA</p>
            </footer>
        </section>        
        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/bootstrap")
    </body>
</html>

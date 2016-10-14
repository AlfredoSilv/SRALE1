<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("SRALE")</title>
    @Styles.Render("~/Content/bootstrapcss/css")
    @Styles.Render("~/Content/bootstrap/duallistbox/css")
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/themes/base/css")
    @Styles.Render("~/Content/multiselectui/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div  id="container" class="container-fluid fill">
        <header id="header" class="row cabecalho">
            <h1>SISTEMA DE REGISTRO DE ANÁLISES LABORATORIAIS EM ETA</h1>
            <p class="nav navbar-text navbar-left">Bem vindo, @User.Identity.Name!</p>
        </header>
    </div>
    <div class="container body-content">     
        @RenderBody() 
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Compesa - GPA</p>
        </footer>
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
</body>
</html>

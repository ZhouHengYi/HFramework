<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="H.Website.IISHost.Pages.ClubMembers.Data" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>S Gallery: Responsive jQuery Gallery Plugin with CSS3 Animations</title>

    <link rel="stylesheet" href="css/demo-styles.css" />
    <link rel="stylesheet" href="css/styles.css" />

</head>

<body>

    <div class="demo-wrapper">
        <!--// Gallery Markup: A container that the plugin is called upon, and two lists for the images (use images with same aspect ratio) //-->
        <div id="gallery-container">
            <ul class="items--small">
                <asp:Literal runat="server" ID="lit_smallImage"></asp:Literal>
            </ul>
            <ul class="items--big">
                <asp:Literal runat="server" ID="lit_bigImage"></asp:Literal>
            </ul>
            <div class="controls">
                <span class="control icon-arrow-left" data-direction="previous"></span>
                <span class="control icon-arrow-right" data-direction="next"></span>
                <span class="grid icon-grid"></span>
                <!--<span class="fs-toggle icon-fullscreen"></span>-->
            </div>

        </div>

    </div>
    <!--end demo-wrapper-->

    <script src="js/jquery-1.8.2.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/scripts.js"></script>
    <script>
        $(document).ready(function () {
            $('#gallery-container').sGallery({
                fullScreenEnabled: true
            });
        });
  </script>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CallingSysFront.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FineUI（开源版）空项目</title>
    <style>
        .header .title a,
        .header .pro a {
            font-weight: bold;
            font-size: 24px;
            text-decoration: none;
            line-height: 50px;
            margin-left: 10px;
        }

        .header .pro {
            position: absolute;
            top: 0;
            right: 10px;
        }

        .bottomtable {
            width: 100%;
            font-size: 12px;
        }


        /* 主题相关样式 - neptune */
        .f-theme-neptune .header,
        .f-theme-neptune .bottomtable,
        .f-theme-neptune .x-splitter {
            background-color: #1475BB;
            color: #fff;
        }

            .f-theme-neptune .header a,
            .f-theme-neptune .bottomtable a {
                color: #fff;
            }

            .f-theme-neptune .header .x-panel-body {
                background-color: transparent;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" Height="50px" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Items>
                        <f:ContentPanel ShowBorder="false" ShowHeader="false" ID="ContentPanel1" CssClass="header"
                            runat="server">
                            <div class="title">
                                <a href="./default.aspx" style="color: #fff;">网上业务及预约取号系统</a>
                            </div>
                            <div class="pro">
                                <a href="http://fineui.com/demo_pro/" target="_blank" style="color: #fff;">取号管理</a>
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" ShowBorder="false" ShowHeader="false" CssClass="bottomtable" runat="server">
                    <Items>
                        <f:Panel ID="panelB" ShowBorder="false" ShowHeader="false" TableConfigColumns="3" Layout="Table" runat="server">
                            <Items>
                                <f:Panel ID="panel11" Width="500px" Height="200px" ShowBorder="true"  TableRowspan="2" runat="server"></f:Panel>
                                <f:Panel ID="panel12" ShowBorder="true" Width="100px" Height="100px" Layout="Fit" runat="server">
                                    <Items>
                                        <f:Button ID="btnGRYW" Text="GRYW" Hidden="true" runat="server"></f:Button>
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="panel13" ShowBorder="true" Width="100px" Height="100px" Layout="Fit" runat="server">
                                    <Items>
                                        <f:Button ID="btnDWYW" Text="DWYW" Hidden="true" runat="server"></f:Button>
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="panel1" ShowBorder="true" Width="100px" Height="100px" Layout="Fit" runat="server">
                                    <Items>
                                        <f:Button ID="Button1" Text="DWYW" Hidden="true" runat="server"></f:Button>
                                    </Items>
                                </f:Panel>

                            </Items>
                        </f:Panel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
    </form>
    <script>

        // 页面控件初始化完毕后，会调用用户自定义的onReady函数
        F.ready(function () {

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            //F.util.initTreeTabStrip(F(menuClientID), F(tabStripClientID), null, true, false, false);

        });
    </script>
</body>
</html>

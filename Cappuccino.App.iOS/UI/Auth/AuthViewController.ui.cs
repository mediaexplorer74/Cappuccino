﻿namespace Cappuccino.App.iOS.UI.Auth;


public partial class AuthViewController {
    private WebKit.WKWebView? webView;

    public override void ViewDidLoad() {
        base.ViewDidLoad();

        this.webView = new WebKit.WKWebView(this.View!.Bounds, new WebKit.WKWebViewConfiguration());
        this.View.AddSubview(webView);

        SetNeedsStatusBarAppearanceUpdate();
    }

    public override UIStatusBarStyle PreferredStatusBarStyle() => UIStatusBarStyle.DarkContent;
}
package md5b9df9925b8c45cc284c8372f3c5dea45;


public class LoginPageRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.PageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XFSocialMedia.Droid.Renderers.LoginPageRenderer, XFSocialMedia.Android", LoginPageRenderer.class, __md_methods);
	}


	public LoginPageRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == LoginPageRenderer.class)
			mono.android.TypeManager.Activate ("XFSocialMedia.Droid.Renderers.LoginPageRenderer, XFSocialMedia.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public LoginPageRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == LoginPageRenderer.class)
			mono.android.TypeManager.Activate ("XFSocialMedia.Droid.Renderers.LoginPageRenderer, XFSocialMedia.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public LoginPageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == LoginPageRenderer.class)
			mono.android.TypeManager.Activate ("XFSocialMedia.Droid.Renderers.LoginPageRenderer, XFSocialMedia.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

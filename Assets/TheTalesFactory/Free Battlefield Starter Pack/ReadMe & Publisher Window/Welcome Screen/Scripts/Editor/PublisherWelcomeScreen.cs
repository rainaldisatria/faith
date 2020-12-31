using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;


[InitializeOnLoad]
public class PublisherWelcomeScreen:EditorWindow
{
	private static PublisherWelcomeScreen window;
	private static Vector2 windowsSize = new Vector2(600f, 800f);
	private Vector2 scrollPosition;

	private static string windowHeaderText = "The Tales Factory";
	private string copyright = "© Copyright " + DateTime.Now.Year + " The Tales Factory";
	
	private const string isShowAtStartEditorPrefs = "WelcomeScreenShowAtStart";
	private static bool isShowAtStart = true;

	private static bool isInited;

	private static GUIStyle headerStyle;
	private static GUIStyle copyrightStyle;
	private static Texture2D youTubeIcon;
    private static Texture2D youTubeIconVideo1;
    private static Texture2D youTubeIconVideo2;
    private static Texture2D youTubeIconVideo3;
    private static Texture2D youTubeIconVideo4;
    private static Texture2D youTubeIconVideo5;

    private static Texture2D unityConnectIcon;

	private static Texture2D facebookIcon;
	private static Texture2D supportIcon;
	private static Texture2D instagramIcon;


	static PublisherWelcomeScreen()
	{
		EditorApplication.update -= GetShowAtStart;
		EditorApplication.update += GetShowAtStart;
	}

	private void OnGUI()
	{
		if (!isInited) 
		{
			Init();
		}

		if (GUI.Button(new Rect(0f, 0f, windowsSize.x, 176), "", headerStyle))
			Process.Start("https://assetstore.unity.com/publishers/39058");

		GUILayoutUtility.GetRect(position.width, 185f);

		scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        if (DrawPreview(youTubeIconVideo1, "Bastion: Low Poly Modular Castle Pack"))
            Process.Start("https://assetstore.unity.com/packages/3d/environments/fantasy/bastion-lowpoly-modular-castle-pack-154739");

        if (DrawPreview(youTubeIconVideo2, "Fallen: Photoscanned Ruins Pack"))
            Process.Start("https://assetstore.unity.com/packages/3d/environments/historic/fallen-photoscanned-ruins-pack-143956");

        if (DrawPreview(youTubeIconVideo3, "Photoscanned Bunkers & Trenches Pack"))
            Process.Start("https://assetstore.unity.com/packages/3d/environments/historic/bunkers-trenches-pack-134999");

        if (DrawPreview(youTubeIconVideo4, "Messerchmitt BF109"))
            Process.Start("https://assetstore.unity.com/packages/3d/vehicles/air/messerschmitt-bf-109-pbr-161305");

        if (DrawPreview(youTubeIconVideo5, "Lands Of Rascal: Western Spaghetti Pack"))
            Process.Start("https://youtu.be/3l146dP1W3s");

        if (DrawButton(supportIcon, "Need Support ?", " Feel free to contact us !")) 
			Process.Start("mailto:thetalesfactory@gmail.com");

        if (DrawButton(unityConnectIcon, "Unity Connect","To connect and share."))
            Process.Start("https://connect.unity.com/u/5bc5c89cedbc2a002509d156");

        if (DrawButton(youTubeIcon, "Our YouTube Channel", "Our video demonstration.")) 
			Process.Start("https://www.youtube.com/channel/UCLQKfrOXz6o426NQiFqP1vA");

		if (DrawButton(instagramIcon, "Follow us on Instagram", "Find out how we work .")) 
			Process.Start("https://www.instagram.com/thetalesfactory/");

        if (DrawButton(facebookIcon, "Follow us on Facebook", " To be informed about our new projects & updates ."))
            Process.Start("https://www.facebook.com/The-Tales-Factory-294882054509299");

        EditorGUILayout.EndScrollView();

		EditorPrefs.SetBool(isShowAtStartEditorPrefs, EditorGUILayout.ToggleLeft("Show at start", !EditorPrefs.HasKey(isShowAtStartEditorPrefs) || EditorPrefs.GetBool(isShowAtStartEditorPrefs, true)));

		EditorGUILayout.LabelField(copyright, copyrightStyle);
	}

	private static bool Init()
	{
		try
		{
			headerStyle = new GUIStyle();
			headerStyle.normal.background = Resources.Load("HeaderLogo") as Texture2D;
			headerStyle.normal.textColor = Color.white;
			headerStyle.fontStyle = FontStyle.Bold;
			headerStyle.padding = new RectOffset(340, 0, 27, 0);
			headerStyle.margin = new RectOffset(0, 0, 0, 0);

			copyrightStyle = new GUIStyle();
			copyrightStyle.alignment = TextAnchor.MiddleRight;

			supportIcon = Resources.Load("Support") as Texture2D;
			youTubeIcon = Resources.Load("YouTube") as Texture2D;
            youTubeIconVideo1= Resources.Load("Project01") as Texture2D;
            youTubeIconVideo2 = Resources.Load("Project02") as Texture2D;
            youTubeIconVideo3 = Resources.Load("Project03") as Texture2D;
            youTubeIconVideo4 = Resources.Load("Project04") as Texture2D;
            youTubeIconVideo5 = Resources.Load("Project05") as Texture2D;

            unityConnectIcon = Resources.Load("UnityConnect") as Texture2D;
			facebookIcon = Resources.Load("Facebook") as Texture2D;
			instagramIcon = Resources.Load("Instagram") as Texture2D;
			
			isInited = true; 
		}
		catch (Exception e)
		{
			Debug.Log("WELCOME SCREEN INIT: " + e);
			return false;
		}

		return true;
	}

	private static bool DrawButton(Texture2D icon, string title = "", string description = "")
	{
		GUILayout.BeginHorizontal();

		GUILayout.Space(10f);
		GUILayout.Box(icon, GUIStyle.none, GUILayout.MaxWidth(48f), GUILayout.MaxHeight(48f));
		GUILayout.Space(10f);

		GUILayout.BeginVertical();

		GUILayout.Space(1f);
		GUILayout.Label(title, EditorStyles.boldLabel);
		GUILayout.Label(description);

        GUILayout.EndVertical();

		GUILayout.EndHorizontal();

		Rect rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);

		GUILayout.Space(10f);

		return Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition);
	}

    private static bool DrawPreview(Texture2D icon, string title = "", string description = "")
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();

        GUILayout.Space(10f);
        GUILayout.Box(icon, GUIStyle.none, GUILayout.MaxWidth(236f), GUILayout.MaxHeight(125f));
        GUILayout.Space(0f);

        GUILayout.Space(1f);
        GUILayout.Label(title, EditorStyles.boldLabel);
        GUILayout.Label(description);
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();

        Rect rect = GUILayoutUtility.GetLastRect();
        EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);

        GUILayout.Space(10f);

        return Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition);
    }

	private static void GetShowAtStart()
	{
		EditorApplication.update -= GetShowAtStart;

		isShowAtStart = !EditorPrefs.HasKey(isShowAtStartEditorPrefs) || EditorPrefs.GetBool(isShowAtStartEditorPrefs, true);

		if (isShowAtStart)
		{
			EditorApplication.update -= OpenAtStartup;
			EditorApplication.update += OpenAtStartup;
		}
	}

	private static void OpenAtStartup()
	{
		if (!isInited && Init())
		{
			OpenWindow();

			EditorApplication.update -= OpenAtStartup;
		}
	}

	[MenuItem("TheTalesFactory/Welcome Screen", false)]
	public static void OpenWindow()
	{
		if (window == null) 
		{
			window = GetWindow<PublisherWelcomeScreen> (true, windowHeaderText, true);
			window.maxSize = window.minSize = windowsSize;
		}
	}

	private void OnEnable()
	{
		window = this;
	}

	private void OnDestroy()
	{
		window = null;
	}
}
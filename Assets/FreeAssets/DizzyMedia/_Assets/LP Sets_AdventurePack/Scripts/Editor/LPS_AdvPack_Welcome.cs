using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;
using System.IO;

[InitializeOnLoad]
public class LPS_AdvPack_Welcome : EditorWindow {


//////////////////////////////////////
///
///     INTERNAL VALUES
///
///////////////////////////////////////


    private static LPS_AdvPack_Welcome window;
    private static Vector2 windowsSize = new Vector2(530, 480f);
    private static string verNumb = " v1.0";
    
    private const string isShowAtStartEditorPrefs = "LPS_AdvPack_WelcomeStart";
    public static bool showOnStart = true;
    private static bool isInited;
    
    private string pipeChar_StandPack = "LPS Adv Characters Standard";
    private string pipeChar_UrpPack = "LPS Adv Characters URP";
    
    private string pipeForest_StandPack = "LPS Adv Forest Standard";
    private string pipeForest_UrpPack = "LPS Adv Forest URP";
    
    private int tabs;


//////////////////////////////////////
///
///     SHOW AT START CHECKS
///
///////////////////////////////////////


	static LPS_AdvPack_Welcome() {
        
		EditorApplication.update -= GetShowAtStart;
		EditorApplication.update += GetShowAtStart;
	
    }//WelcomeScreen
    
	private static void GetShowAtStart() {
        
		EditorApplication.update -= GetShowAtStart;
		
        if(EditorPrefs.HasKey(isShowAtStartEditorPrefs)){
        
            showOnStart = EditorPrefs.GetBool(isShowAtStartEditorPrefs);
        
        //HasKey
        } else {
        
            showOnStart = true;
            EditorPrefs.SetBool(isShowAtStartEditorPrefs, showOnStart);
            
        }//HasKey

		if(showOnStart) {
            
			EditorApplication.update -= OpenAtStartup;
			EditorApplication.update += OpenAtStartup;
		
        }//showOnStart
        
	}//GetShowAtStart

	private static void OpenAtStartup() {
        
        OpenWizard();
        EditorApplication.update -= OpenAtStartup;

	}//OpenAtStartup
    
    
//////////////////////////////////////
///
///     EDITOR WINDOW
///
///////////////////////////////////////

    [MenuItem("Dizzy Media/Low Poly Sets/Adventure Pack/Review Asset", false , 13)]
    public static void OpenReview() {
            
        Application.OpenURL("https://u3d.as/2G5h#reviews");
        
    }//OpenReview
    
    [MenuItem("Dizzy Media/Low Poly Sets/Adventure Pack/Adv Pack Welcome", false , 12)]
    public static void OpenWizard() {
            
        window = GetWindow<LPS_AdvPack_Welcome>(false, "LPS : Adv Pack" + verNumb, true);
        window.maxSize = window.minSize = windowsSize;
        
    }//OpenWizard

    private void OnGUI() {
            
        GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            
        Texture t0 = (Texture)Resources.Load("EditorContent/LPS_AdvPack-Logo");
        
        var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter};
            
        GUILayout.Box(t0, style, GUILayout.ExpandWidth(true), GUILayout.Height(200));
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        AdvPack_WelcomeScreen();
            
    }//OnGUI
    
    
//////////////////////////////////////
///
///     EDITOR DISPLAY
///
///////////////////////////////////////

    
    public void AdvPack_WelcomeScreen(){
    
        tabs = GUILayout.SelectionGrid(tabs, new string[] { "Welcome", "Characters", "Forest"}, 3);
        
        EditorGUILayout.Space();
        
        if(tabs == 0){
        
            EditorGUILayout.HelpBox("\n" + "Hello and welcome to Low Poly Sets : Adventure Pack! " + "\n" + "\n" + "The assets in this pack support both Standard and URP rendering pipelines. If you want to use a certain pipeline use the import buttons in the each tab." + "\n", MessageType.Info); 
            
            EditorGUILayout.Space();
            
            if(GUILayout.Button("Review Asset")) {

                OpenReview();

            }//Button
            
            GUILayout.Space(10);
            
            showOnStart = EditorGUILayout.Toggle("Show On Start", showOnStart);
            
        }//tabs = welcome
        
        if(tabs == 1){
        
            EditorGUILayout.HelpBox("\n" + "Adventure Characters is fully compatible with Standard and URP pipelines, use the buttons below to upgrade the package to your desired pipeline." + "\n" + "\n" + "(The default is standard but the standard import button is available here if you want to revert back to standard from URP)" + "\n", MessageType.Info);
            
            GUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            if(GUILayout.Button("Import Standard")) {

                ImportPack(pipeChar_StandPack);

            }//Button
            
            if(GUILayout.Button("Import URP")) {

                ImportPack(pipeChar_UrpPack);

            }//Button

            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space();
        
        }//tabs = characters
        
        if(tabs == 2){
        
            EditorGUILayout.HelpBox("\n" + "Adventure Forest is fully compatible with Standard and URP pipelines, use the buttons below to upgrade the package to your desired pipeline." + "\n" + "\n" + "(The default is standard but the standard import button is available here if you want to revert back to standard from URP)" + "\n", MessageType.Info);
            
            GUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            if(GUILayout.Button("Import Standard")) {

                ImportPack(pipeForest_StandPack);

            }//Button
            
            if(GUILayout.Button("Import URP")) {

                ImportPack(pipeForest_UrpPack);

            }//Button

            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space();
        
        }//tabs = characters
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        EditorGUILayout.Space();
        
    }//AdvPack_WelcomeScreen
    
    
//////////////////////////////////////
///
///     EXTRAS
///
///////////////////////////////////////

    
    public void ImportPack(string packName){
        
        string[] results = new string[0];
        
        results = AssetDatabase.FindAssets(packName);
        
        if(results.Length > 0){
            
            foreach(string pack in results) {
                
                AssetDatabase.ImportPackage(AssetDatabase.GUIDToAssetPath(pack), true);
                
            }//foreach pack
            
        //results > 0
        } else {
        
            Debug.Log(packName + " Not Found!");
        
        }//results > 0
        
    }//ImportPack
    
	private void OnDestroy(){
        
        window = null;
		EditorPrefs.SetBool(isShowAtStartEditorPrefs, showOnStart);
	
    }//OnDestroy

}

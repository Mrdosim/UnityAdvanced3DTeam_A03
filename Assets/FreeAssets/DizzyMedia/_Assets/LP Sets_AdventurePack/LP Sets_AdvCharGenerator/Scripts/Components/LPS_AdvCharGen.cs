using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class LPS_AdvCharGen : MonoBehaviour {
    
    
//////////////////////////////////////
///
///     CLASSES
///
//////////////////////////////////////
    
    
    [System.Serializable]
    public class Menu_Animations {
    
        [Space]
    
        public Anim_Holders charType;
        public Anim_Holders bodyPieces;
        public Anim_Holders mainBody;
        public Anim_Holders bottom;
        
        [Space]
    
        public Anim_Holders savePrefab;
        public Anim_Holders prefabCharName;
    
    }//Menu_Animations
    
    [System.Serializable]
    public class Anim_Holders {
    
        [Space]
    
        public GameObject holder;
        
        [Space]

        public Animator anim;
        
        public string show;
        public string hide;
    
    }//Anim_Holders
    
    [System.Serializable]
    public class References_UI {
        
        [Space]
        
        public GameObject mainBodyHolder;
        public GameObject bodyPiecesHolder;
        
        [Space]
        
        public UI_Dropdowns belts;
        public UI_Dropdowns brows;
        public UI_Dropdowns bucklesInner;
        public UI_Dropdowns bucklesOuter;
        public UI_Dropdowns collars;
        public UI_Dropdowns clothsInner;
        public UI_Dropdowns clothsOuter;
        public UI_Dropdowns horns;
        public UI_Dropdowns shoulderPads;
        
    }//References_UI
    
    [System.Serializable]
    public class UI_Dropdowns {
        
        [Space]
        
        public Dropdown part;
        public Dropdown material;
        
    }//UI_Dropdowns
    
    [System.Serializable]
    public class CharacterType {
        
        [Space]
        
        public BodyPieces player;
        public BodyPieces enemy;

    }//CharacterType
    
    [System.Serializable]
    public class BodyPieces {
        
        [Space]
        
        public References_UI referencesUI;
        
        [Space]
        
        public MainBodyPieces[] mainBody;
        
        [Space]
        
        public Pieces[] belts;
        public Pieces[] brows;
        public Pieces[] bucklesInner;
        public Pieces[] bucklesOuter;
        public Pieces[] collars;
        public Pieces[] clothsInner;
        public Pieces[] clothsOuter;
        public Pieces[] horns;
        public Pieces[] shoulderPads;
        
    }//BodyPieces
    
    [System.Serializable]
    public class MainBodyPieces {
        
        [Space]
        
        public string name;
        public SkinnedMeshRenderer mesh;
        
        [Space]
        
        public Text header;
        public Dropdown dropdown;
        
        [Space]
        
        public Material[] materials;
        
    }//MainBodyPieces
        
    [System.Serializable]    
    public class Pieces {
        
        [Space]
        
        public string name;
        public GameObject holder;
        public SkinnedMeshRenderer mesh;
        
        [Space]
        
        public Material[] materials;
        
    }//Pieces   
    

//////////////////////////////////////
///
///     ENUMS
///
///////////////////////////////////////
    
    
    public enum CharType_Current {
        
        Player = 0,
        Enemy = 1,
        
    }//CharType_Current
    
    
//////////////////////////////////////
///
///     VALUES
///
///////////////////////////////////////
    
/////////////////////////
///
///     USER OPTIONS
///
/////////////////////////

    
    [Space]
    
    [Header("User Options")]
    
    [Space]
    
    public GameObject characterHolder;
    
    public InputField charNameInput;
    public Text prefabSaveHeader;
    
    [Space]
    
    public Menu_Animations menuAnimations;
    
    [Space]
    
    public CharacterType characterType;
        
    
/////////////////////////
///
///     AUTO
///
/////////////////////////
    
    
    [Space]
    
    [Header("Auto")]
    
    [Space]
    
    public CharType_Current charTypeCurrent;
    
    private List<Dropdown.OptionData> bodyOptions = new List<Dropdown.OptionData>();
    private Dropdown.OptionData newData = new Dropdown.OptionData();
    
    private int tempBelt;
    private int tempBeltChance;
    private int tempBeltMat;
    
    private int tempBrow;
    private int tempBrowMat;
    
    private int tempBuckInner;
    private int tempBuckInnerChance;
    private int tempBuckInnerMat;
    
    private int tempBuckOuter;
    private int tempBuckOuterChance;
    private int tempBuckOuterMat;
    
    private int tempCollar;
    private int tempCollarChance;
    private int tempCollarMat;
    
    private int tempClothInner;
    private int tempClothInnerChance;
    private int tempClothInnerMat;
    
    private int tempClothOuter;
    private int tempClothOuterChance;
    private int tempClothOuterMat;
    
    private int tempHorns;
    private int tempHornsChance;
    private int tempHornsMat;
    
    private int tempShouldPad;
    private int tempShouldPadsChance;
    private int tempShouldPadMat;

    private int tempHeadMat;
    private int tempNeckMat;
    private int tempEyesMat;
    private int tempTorsoMat;
    private int tempPelvisMat;
    private int tempHandsMat;
    private int tempFeetMat;
    private int tempLegsMat;
    private int tempLegsUpperMat;
    
    private string tempSavePath;
    private bool saveSuccess;
    
    
//////////////////////////////////////
///
///     START ACTIONS
///
///////////////////////////////////////
    
    
    void Start() {
        
        StartInit();
        
    }//Start
    
    public void StartInit(){
        
        charTypeCurrent = CharType_Current.Player;
        
        tempBelt = -1;
        tempBeltChance = -1;
        tempBeltMat = -1;
        
        tempBrow = -1;
        tempBrowMat = -1;
        
        tempBuckInner = -1;
        tempBuckInnerChance = -1;
        tempBuckInnerMat = -1;
        
        tempBuckOuter = -1;
        tempBuckOuterChance = -1;
        tempBuckOuterMat = -1;
        
        tempCollar = -1;
        tempCollarChance = -1;
        tempCollarMat = -1;
        
        tempClothInner = -1;
        tempClothInnerChance = -1;
        tempClothInnerMat = -1;
        
        tempClothOuter = -1;
        tempClothOuterChance = -1;
        tempClothOuterMat = -1;
        
        tempHorns = -1;
        tempHornsChance = -1;
        tempHornsMat = -1;
        
        tempShouldPad = -1;
        tempShouldPadsChance = -1;
        tempShouldPadMat = -1;
        
        tempHeadMat = -1;
        tempNeckMat = -1;
        tempEyesMat = -1;
        tempTorsoMat = -1;
        tempPelvisMat = -1;
        tempHandsMat = -1;
        tempFeetMat = -1;
        tempLegsMat = -1;
        tempLegsUpperMat = -1;
        
        OptionsAdd_MainBody();
        
        OptionsAdd_Belts();
        OptionsAdd_Brows();
        OptionsAdd_BucksInner();
        OptionsAdd_BucksOuter();
        OptionsAdd_Collars();
        OptionsAdd_ClothsInner();
        OptionsAdd_ClothsOuter();
        OptionsAdd_Horns();
        OptionsAdd_ShouldPads();
        
        DefaultsSet_Check();
        
    }//StartInit
    
    
//////////////////////////////////////
///
///     DROPDOWN ACTIONS
///
///////////////////////////////////////
    
//////////////////////////////
///
///     OPTIONS UPDATE
///
//////////////////////////////
    
////////////////////
///
///     MAIN BODY OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_MainBody(){
        
        
/////////////
///
///     PLAYER
///
/////////////
        
        
        if(characterType.player.mainBody.Length > 0){
        
            for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                if(characterType.player.mainBody[mb].header.text != characterType.player.mainBody[mb].name){

                    characterType.player.mainBody[mb].header.text = characterType.player.mainBody[mb].name;

                }//name = text

                if(characterType.player.mainBody[mb].name == characterType.player.mainBody[mb].header.text){

                    bodyOptions = new List<Dropdown.OptionData>();

                    for(int mbmat = 0; mbmat < characterType.player.mainBody[mb].materials.Length; mbmat++) {

                        newData = new Dropdown.OptionData();
                        newData.text = characterType.player.mainBody[mb].materials[mbmat].name;
                        bodyOptions.Add(newData);

                    }//for mbmat player.mainBody[mb].materials 

                    foreach(Dropdown.OptionData newOpt in bodyOptions) {

                        characterType.player.mainBody[mb].dropdown.options.Add(newOpt);

                    }//foreach bodyOptions

                    characterType.player.mainBody[mb].dropdown.captionText.text = bodyOptions[0].text;

                }//name = text

            }//for mb player.mainBody 
            
        }//player.mainBody.Length > 0
        
        
/////////////
///
///     ENEMY
///
/////////////
        
        
        if(characterType.enemy.mainBody.Length > 0){
        
            for(int mbe = 0; mbe < characterType.enemy.mainBody.Length; mbe++) {

                if(characterType.enemy.mainBody[mbe].header.text != characterType.enemy.mainBody[mbe].name){

                    characterType.enemy.mainBody[mbe].header.text = characterType.enemy.mainBody[mbe].name;

                }//name = text

                if(characterType.enemy.mainBody[mbe].name == characterType.enemy.mainBody[mbe].header.text){

                    bodyOptions = new List<Dropdown.OptionData>();

                    for(int mbmat = 0; mbmat < characterType.enemy.mainBody[mbe].materials.Length; mbmat++) {

                        newData = new Dropdown.OptionData();
                        newData.text = characterType.enemy.mainBody[mbe].materials[mbmat].name;
                        bodyOptions.Add(newData);

                    }//for mbmat enemy.mainBody[mb].materials 

                    foreach(Dropdown.OptionData newOpt in bodyOptions) {

                        characterType.enemy.mainBody[mbe].dropdown.options.Add(newOpt);

                    }//foreach bodyOptions

                }//name = text

            }//for mbe enemy.mainBody
        
        }//enemy.mainBody.Length > 0
        
    }//OptionsAdd_MainBody
    
    
////////////////////
///
///     BELT OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_Belts(){
        
        
////////////
///
///     PLAYER
///
////////////
        
////////
///
///     BELT PARTS OPTIONS
///
////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.belts.Length > 0){
        
            for(int blts = 0; blts < characterType.player.belts.Length; blts++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.belts[blts].name;
                bodyOptions.Add(newData); 

            }//for blts player.belts

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.belts.part.options.Add(newOpt);

            }//foreach bodyOptions


////////
///
///     BELT PARTS MATERIALS OPTIONS
///
////////


            for(int blts = 0; blts < characterType.player.belts.Length; blts++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int pblt = 0; pblt < characterType.player.belts[blts].materials.Length; pblt++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.belts[blts].materials[pblt].name;
                    bodyOptions.Add(newData);

                }//for pblt player.belts[pblt].materials 

            }//for blts player.belts

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.belts.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.belts.material.captionText.text = bodyOptions[0].text;
            
        }//player.belts.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
////////
///
///     BELT PARTS OPTIONS
///
////////
        
        
        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.belts.Length > 0){
        
            for(int blts = 0; blts < characterType.enemy.belts.Length; blts++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.belts[blts].name;
                bodyOptions.Add(newData); 

            }//for blts enemy.belts

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.belts.part.options.Add(newOpt);

            }//foreach bodyOptions


////////
///
///     BELT PARTS MATERIALS OPTIONS
///
////////


            for(int blts = 0; blts < characterType.enemy.belts.Length; blts++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int pblt = 0; pblt < characterType.enemy.belts[blts].materials.Length; pblt++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.belts[blts].materials[pblt].name;
                    bodyOptions.Add(newData);

                }//for pblt enemy.belts[pblt].materials 

            }//for blts enemy.belts

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.belts.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.belts.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.belts.Length > 0
        
    }//OptionsAdd_Belts
    
    
////////////////////
///
///     BROWS OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_Brows(){
        
        
////////////
///
///     PLAYER
///
////////////
        
////////
///
///     BROWS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.brows.Length > 0){
        
            for(int brws = 0; brws < characterType.player.brows.Length; brws++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.brows[brws].name;
                bodyOptions.Add(newData); 

            }//for brws player.brows

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.brows.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
////////////
///
///     BROWS PARTS MATERIALS OPTIONS
///
////////////
        
        
            for(int brws = 0; brws < characterType.player.brows.Length; brws++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int pbrws = 0; pbrws < characterType.player.brows[brws].materials.Length; pbrws++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.brows[brws].materials[pbrws].name;
                    bodyOptions.Add(newData);

                }//for pbrws player.brows[brws].materials 

            }//for brws player.brows

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.brows.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.brows.material.captionText.text = bodyOptions[0].text;
            
        }//player.brows.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
////////
///
///     BROWS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.brows.Length > 0){
        
            for(int brws = 0; brws < characterType.enemy.brows.Length; brws++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.brows[brws].name;
                bodyOptions.Add(newData); 

            }//for brws enemy.brows

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.brows.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     BROWS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int brws = 0; brws < characterType.enemy.brows.Length; brws++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int pbrws = 0; pbrws < characterType.enemy.brows[brws].materials.Length; pbrws++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.brows[brws].materials[pbrws].name;
                    bodyOptions.Add(newData);

                }//for pbrws enemy.brows[brws].materials 

            }//for brws enemy.brows

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.brows.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.brows.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.brows.Length > 0
        
    }//OptionsAdd_Brows
    
    
////////////////////
///
///     BUCKLES INNER OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_BucksInner(){
        
        
////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     BUCKLES INNER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.bucklesInner.Length > 0){
        
            for(int bli = 0; bli < characterType.player.bucklesInner.Length; bli++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.bucklesInner[bli].name;
                bodyOptions.Add(newData); 

            }//for bli player.bucklesInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.bucklesInner.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     BUCKLES INNER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int bli = 0; bli < characterType.player.bucklesInner.Length; bli++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int blim = 0; blim < characterType.player.bucklesInner[bli].materials.Length; blim++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.bucklesInner[bli].materials[blim].name;
                    bodyOptions.Add(newData);

                }//for blim player.bucklesInner[bli].materials 

            }//for bli player.bucklesInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.bucklesInner.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.bucklesInner.material.captionText.text = bodyOptions[0].text;
            
        }//player.bucklesInner.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     BUCKLES INNER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.bucklesInner.Length > 0){
        
            for(int bli = 0; bli < characterType.enemy.bucklesInner.Length; bli++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.bucklesInner[bli].name;
                bodyOptions.Add(newData); 

            }//for bli enemy.bucklesInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.bucklesInner.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     BUCKLES INNER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int bli = 0; bli < characterType.enemy.bucklesInner.Length; bli++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int blim = 0; blim < characterType.enemy.bucklesInner[bli].materials.Length; blim++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.bucklesInner[bli].materials[blim].name;
                    bodyOptions.Add(newData);

                }//for blim enemy.bucklesInner[bli].materials 

            }//for bli enemy.bucklesInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.bucklesInner.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.bucklesInner.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.bucklesInner.Length > 0
        
    }//OptionsAdd_BucksInner
    
    
////////////////////
///
///     BUCKLES OUTER OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_BucksOuter(){
        
        
////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     BUCKLES OUTER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.bucklesOuter.Length > 0){
        
            for(int blo = 0; blo < characterType.player.bucklesOuter.Length; blo++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.bucklesOuter[blo].name;
                bodyOptions.Add(newData); 

            }//for blo player.bucklesOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.bucklesOuter.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     BUCKLES OUTER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int blo = 0; blo < characterType.player.bucklesOuter.Length; blo++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int blom = 0; blom < characterType.player.bucklesOuter[blo].materials.Length; blom++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.bucklesOuter[blo].materials[blom].name;
                    bodyOptions.Add(newData);

                }//for blom player.bucklesOuter[blo].materials 

            }//for blo player.bucklesOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.bucklesOuter.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.bucklesOuter.material.captionText.text = bodyOptions[0].text;
            
        }//player.bucklesOuter.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     BUCKLES OUTER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.bucklesOuter.Length > 0){
        
            for(int blo = 0; blo < characterType.enemy.bucklesOuter.Length; blo++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.bucklesOuter[blo].name;
                bodyOptions.Add(newData); 

            }//for blo enemy.bucklesOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.bucklesOuter.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     BUCKLES OUTER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int blo = 0; blo < characterType.enemy.bucklesOuter.Length; blo++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int blom = 0; blom < characterType.enemy.bucklesOuter[blo].materials.Length; blom++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.bucklesOuter[blo].materials[blom].name;
                    bodyOptions.Add(newData);

                }//for blom enemy.bucklesOuter[blo].materials 

            }//for blo enemy.bucklesOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.bucklesOuter.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.bucklesOuter.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.bucklesOuter.Length > 0
        
    }//OptionsAdd_BucksOuter
    
    
////////////////////
///
///     COLLARS OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_Collars(){
        

////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     COLLARS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.collars.Length > 0){
        
            for(int col = 0; col < characterType.player.collars.Length; col++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.collars[col].name;
                bodyOptions.Add(newData); 

            }//for clo player.collars

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.collars.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     COLLARS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int col = 0; col < characterType.player.collars.Length; col++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int colm = 0; colm < characterType.player.collars[col].materials.Length; colm++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.collars[col].materials[colm].name;
                    bodyOptions.Add(newData);

                }//for colm player.collars[col].materials 

            }//for col player.collars

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.collars.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.collars.material.captionText.text = bodyOptions[0].text;
            
        }//player.collars.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     COLLARS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.collars.Length > 0){
        
            for(int col = 0; col < characterType.enemy.collars.Length; col++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.collars[col].name;
                bodyOptions.Add(newData); 

            }//for clo enemy.collars

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.collars.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     COLLARS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int col = 0; col < characterType.enemy.collars.Length; col++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int colm = 0; colm < characterType.enemy.collars[col].materials.Length; colm++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.collars[col].materials[colm].name;
                    bodyOptions.Add(newData);

                }//for colm enemy.collars[col].materials 

            }//for col enemy.collars

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.collars.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.collars.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.collars.Length > 0
        
    }//OptionsAdd_Collars
    
    
////////////////////
///
///     CLOTHS INNER OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_ClothsInner(){
        
        
////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     CLOTHS INNER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.clothsInner.Length > 0){
        
            for(int cli = 0; cli < characterType.player.clothsInner.Length; cli++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.clothsInner[cli].name;
                bodyOptions.Add(newData); 

            }//for cli player.clothsInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.clothsInner.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     CLOTHS INNER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int cli = 0; cli < characterType.player.clothsInner.Length; cli++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int clim = 0; clim < characterType.player.clothsInner[cli].materials.Length; clim++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.clothsInner[cli].materials[clim].name;
                    bodyOptions.Add(newData);

                }//for clim player.clothsInner[cli].materials 

            }//for cli player.clothsInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.clothsInner.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.clothsInner.material.captionText.text = bodyOptions[0].text;
            
        }//player.clothsInner.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     CLOTHS INNER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.clothsInner.Length > 0){
        
            for(int cli = 0; cli < characterType.enemy.clothsInner.Length; cli++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.clothsInner[cli].name;
                bodyOptions.Add(newData); 

            }//for cli enemy.clothsInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.clothsInner.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     CLOTHS INNER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int cli = 0; cli < characterType.enemy.clothsInner.Length; cli++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int clim = 0; clim < characterType.enemy.clothsInner[cli].materials.Length; clim++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.clothsInner[cli].materials[clim].name;
                    bodyOptions.Add(newData);

                }//for clim enemy.clothsInner[cli].materials 

            }//for cli enemy.clothsInner

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.clothsInner.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.clothsInner.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.clothsInner.Length > 0
        
    }//OptionsAdd_ClothsInner
    
    
////////////////////
///
///     CLOTHS OUTER OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_ClothsOuter(){
        
        
////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     CLOTHS OUTER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.clothsOuter.Length > 0){
        
            for(int clo = 0; clo < characterType.player.clothsOuter.Length; clo++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.clothsOuter[clo].name;
                bodyOptions.Add(newData); 

            }//for clo player.clothsOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.clothsOuter.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     CLOTHS OUTER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int clo = 0; clo < characterType.player.clothsOuter.Length; clo++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int clom = 0; clom < characterType.player.clothsOuter[clo].materials.Length; clom++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.clothsOuter[clo].materials[clom].name;
                    bodyOptions.Add(newData);

                }//for clom player.clothsOuter[clo].materials 

            }//for clo player.clothsOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.clothsOuter.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.clothsOuter.material.captionText.text = bodyOptions[0].text;
            
        }//player.clothsOuter.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     CLOTHS OUTER PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.clothsOuter.Length > 0){
        
            for(int clo = 0; clo < characterType.enemy.clothsOuter.Length; clo++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.clothsOuter[clo].name;
                bodyOptions.Add(newData); 

            }//for clo enemy.clothsOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.clothsOuter.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     CLOTHS OUTER PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int clo = 0; clo < characterType.enemy.clothsOuter.Length; clo++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int clom = 0; clom < characterType.enemy.clothsOuter[clo].materials.Length; clom++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.clothsOuter[clo].materials[clom].name;
                    bodyOptions.Add(newData);

                }//for clom enemy.clothsOuter[clo].materials 

            }//for clo enemy.clothsOuter

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.clothsOuter.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.clothsOuter.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.clothsOuter.Length > 0
        
    }//OptionsAdd_ClothsOuter
    
    
////////////////////
///
///     HORNS OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_Horns(){
        
        
////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     HORNS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();

        if(characterType.player.horns.Length > 0){
        
            for(int hrn = 0; hrn < characterType.player.horns.Length; hrn++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.horns[hrn].name;
                bodyOptions.Add(newData); 

            }//for hrn player.horns

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.horns.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     HORNS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int hrn = 0; hrn < characterType.player.horns.Length; hrn++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int hrnm = 0; hrnm < characterType.player.horns[hrn].materials.Length; hrnm++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.horns[hrn].materials[hrnm].name;
                    bodyOptions.Add(newData);

                }//for hrnm player.horns[hrn].materials 

            }//for hrn player.horns

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.horns.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.horns.material.captionText.text = bodyOptions[0].text;

        }//player.horns.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     HORNS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();

        if(characterType.enemy.horns.Length > 0){
        
            for(int hrn = 0; hrn < characterType.enemy.horns.Length; hrn++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.horns[hrn].name;
                bodyOptions.Add(newData); 

            }//for hrn enemy.horns

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.horns.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     HORNS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int hrn = 0; hrn < characterType.enemy.horns.Length; hrn++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int hrnm = 0; hrnm < characterType.enemy.horns[hrn].materials.Length; hrnm++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.horns[hrn].materials[hrnm].name;
                    bodyOptions.Add(newData);

                }//for hrnm enemy.horns[hrn].materials 

            }//for hrn enemy.horns

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.horns.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.horns.material.captionText.text = bodyOptions[0].text;

        }//enemy.horns.Length > 0
        
    }//OptionsAdd_Horns
    
    
////////////////////
///
///     SHOULDER PADS OPTIONS
///
////////////////////
    
    
    public void OptionsAdd_ShouldPads(){
        
        
////////////
///
///     PLAYER
///
////////////
        
/////////
///
///     SHOULDER PADS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.player.shoulderPads.Length > 0){
        
            for(int shp = 0; shp < characterType.player.shoulderPads.Length; shp++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.player.shoulderPads[shp].name;
                bodyOptions.Add(newData); 

            }//for shp player.shoulderPads

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.shoulderPads.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     SHOULDER PADS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int shp = 0; shp < characterType.player.shoulderPads.Length; shp++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int shpm = 0; shpm < characterType.player.shoulderPads[shp].materials.Length; shpm++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.player.shoulderPads[shp].materials[shpm].name;
                    bodyOptions.Add(newData);

                }//for shpm player.shoulderPads[shp].materials 

            }//for shp player.shoulderPads

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.player.referencesUI.shoulderPads.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.player.referencesUI.shoulderPads.material.captionText.text = bodyOptions[0].text;
            
        }//player.shoulderPads.Length > 0
        
        
////////////
///
///     ENEMY
///
////////////
        
/////////
///
///     SHOULDER PADS PARTS OPTIONS
///
/////////
        

        bodyOptions = new List<Dropdown.OptionData>();
        
        if(characterType.enemy.shoulderPads.Length > 0){
        
            for(int shp = 0; shp < characterType.enemy.shoulderPads.Length; shp++) {

                newData = new Dropdown.OptionData();
                newData.text = characterType.enemy.shoulderPads[shp].name;
                bodyOptions.Add(newData); 

            }//for shp enemy.shoulderPads

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.shoulderPads.part.options.Add(newOpt);

            }//foreach bodyOptions
        
        
/////////
///
///     SHOULDER PADS PARTS MATERIALS OPTIONS
///
/////////
        
        
            for(int shp = 0; shp < characterType.enemy.shoulderPads.Length; shp++) {

                bodyOptions = new List<Dropdown.OptionData>();

                for(int shpm = 0; shpm < characterType.enemy.shoulderPads[shp].materials.Length; shpm++) {

                    newData = new Dropdown.OptionData();
                    newData.text = characterType.enemy.shoulderPads[shp].materials[shpm].name;
                    bodyOptions.Add(newData);

                }//for shpm enemy.shoulderPads[shp].materials 

            }//for shp enemy.shoulderPads

            foreach(Dropdown.OptionData newOpt in bodyOptions) {

                characterType.enemy.referencesUI.shoulderPads.material.options.Add(newOpt);

            }//foreach bodyOptions

            characterType.enemy.referencesUI.shoulderPads.material.captionText.text = bodyOptions[0].text;
            
        }//enemy.shoulderPads.Length > 0
        
    }//OptionsAdd_ShouldPads
    
    
//////////////////////////////
///
///     OBJECT SET
///
//////////////////////////////
    
////////////////////
///
///     BELT SET
///
////////////////////
    
    
    public void Belt_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.belts.Length > 0){
                    
                    for(int blts = 0; blts < characterType.player.belts.Length; blts++) {

                        characterType.player.belts[blts].holder.SetActive(false);

                    }//for blts player.belts 

                    characterType.player.belts[type - 1].holder.SetActive(true);
                
                }//belts.Length > 0
                
                if(characterType.player.referencesUI.belts.material != null){
                    
                    characterType.player.referencesUI.belts.material.interactable = true;
                
                }//belts.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.belts.Length > 0){
                
                    for(int blts = 0; blts < characterType.enemy.belts.Length; blts++) {

                        characterType.enemy.belts[blts].holder.SetActive(false);

                    }//for blts player.belts 

                    characterType.enemy.belts[type - 1].holder.SetActive(true);
                
                }//belts.Length > 0
                
                if(characterType.enemy.referencesUI.belts.material != null){
                    
                    characterType.enemy.referencesUI.belts.material.interactable = true;
                
                }//belts.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.belts.Length > 0){
                
                    for(int blts = 0; blts < characterType.player.belts.Length; blts++) {

                        characterType.player.belts[blts].holder.SetActive(false);

                    }//for blts player.belts
                
                }//belts.Length > 0
                    
                if(characterType.player.referencesUI.belts.material != null){
                    
                    characterType.player.referencesUI.belts.material.interactable = false;
            
                }//belts.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.belts.Length > 0){
                
                    for(int blts = 0; blts < characterType.enemy.belts.Length; blts++) {

                        characterType.enemy.belts[blts].holder.SetActive(false);

                    }//for blts player.belts
                
                }//belts.Length > 0
                    
                if(characterType.enemy.referencesUI.belts.material != null){
                    
                    characterType.enemy.referencesUI.belts.material.interactable = false;
            
                }//belts.material != null
                
            }//charTypeCurrent = enemy
            
        }//type > 0
        
    }//Belt_Set
    
    
////////////////////
///
///     EYEBROW SET
///
////////////////////
    
    
    public void EyeBrow_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.brows.Length > 0){
                
                    for(int brws = 0; brws < characterType.player.brows.Length; brws++) {

                        characterType.player.brows[brws].holder.SetActive(false);

                    }//for brws player.brows 

                    characterType.player.brows[type - 1].holder.SetActive(true);
                
                }//brows.Length > 0
                    
                if(characterType.player.referencesUI.brows.material != null){
                    
                    characterType.player.referencesUI.brows.material.interactable = true;
                
                }//brows.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.brows.Length > 0){
                
                    for(int brws = 0; brws < characterType.enemy.brows.Length; brws++) {

                        characterType.enemy.brows[brws].holder.SetActive(false);

                    }//for brws player.brows 

                    characterType.enemy.brows[type - 1].holder.SetActive(true);
                
                }//brows.Length > 0
                    
                if(characterType.enemy.referencesUI.brows.material != null){
                    
                    characterType.enemy.referencesUI.brows.material.interactable = true;
                
                }//brows.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.brows.Length > 0){
                
                    for(int brws = 0; brws < characterType.player.brows.Length; brws++) {

                        characterType.player.brows[brws].holder.SetActive(false);

                    }//for brws player.brows
                
                }//brows.Length > 0
                    
                if(characterType.player.referencesUI.brows.material != null){
                    
                    characterType.player.referencesUI.brows.material.interactable = false;
            
                }//brows.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.brows.Length > 0){
                
                    for(int brws = 0; brws < characterType.enemy.brows.Length; brws++) {

                        characterType.enemy.brows[brws].holder.SetActive(false);

                    }//for brws player.brows
                
                }//brows.Length > 0
                    
                if(characterType.enemy.referencesUI.brows.material != null){
                    
                    characterType.enemy.referencesUI.brows.material.interactable = false;
            
                }//brows.material != null
                
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//EyeBrow_Set
    
    
////////////////////
///
///     BUCKELS INNER SET
///
////////////////////
    
    
    public void BucklesInner_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.bucklesInner.Length > 0){
                
                    for(int bli = 0; bli < characterType.player.bucklesInner.Length; bli++) {

                        characterType.player.bucklesInner[bli].holder.SetActive(false);

                    }//for bli player.bucklesInner 

                    characterType.player.bucklesInner[type - 1].holder.SetActive(true);
                
                }//bucklesInner.Length > 0
                    
                if(characterType.player.referencesUI.bucklesInner.material != null){
                    
                    characterType.player.referencesUI.bucklesInner.material.interactable = true;
                
                }//bucklesInner.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.bucklesInner.Length > 0){
                
                    for(int bli = 0; bli < characterType.enemy.bucklesInner.Length; bli++) {

                        characterType.enemy.bucklesInner[bli].holder.SetActive(false);

                    }//for bli player.bucklesInner 

                    characterType.enemy.bucklesInner[type - 1].holder.SetActive(true);
                
                }//bucklesInner.Length > 0
                    
                if(characterType.enemy.referencesUI.bucklesInner.material != null){
                    
                    characterType.enemy.referencesUI.bucklesInner.material.interactable = true;
                
                }//bucklesInner.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.bucklesInner.Length > 0){
                
                    for(int bli = 0; bli < characterType.player.bucklesInner.Length; bli++) {

                        characterType.player.bucklesInner[bli].holder.SetActive(false);

                    }//for bli player.bucklesInner  
                    
                }//bucklesInner.Length > 0
            
                if(characterType.player.referencesUI.bucklesInner.material != null){
                    
                    characterType.player.referencesUI.bucklesInner.material.interactable = false;
                
                }//bucklesInner.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.bucklesInner.Length > 0){
                
                    for(int bli = 0; bli < characterType.enemy.bucklesInner.Length; bli++) {

                        characterType.enemy.bucklesInner[bli].holder.SetActive(false);

                    }//for bli player.bucklesInner
                
                }//bucklesInner.Length > 0
                    
                if(characterType.enemy.referencesUI.bucklesInner.material != null){
                    
                    characterType.enemy.referencesUI.bucklesInner.material.interactable = false;
            
                }//bucklesInner.material != null
                
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//BucklesInner_Set
    
    
////////////////////
///
///     BUCKELS OUTER SET
///
////////////////////
    
    
    public void BucklesOuter_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.bucklesOuter.Length > 0){
                
                    for(int blo = 0; blo < characterType.player.bucklesOuter.Length; blo++) {

                        characterType.player.bucklesOuter[blo].holder.SetActive(false);

                    }//for blo player.bucklesOuter 

                    characterType.player.bucklesOuter[type - 1].holder.SetActive(true);
                
                }//bucklesOuter.Length > 0
                    
                if(characterType.player.referencesUI.bucklesOuter.material != null){
                    
                    characterType.player.referencesUI.bucklesOuter.material.interactable = true;
                
                }//bucklesOuter.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.bucklesOuter.Length > 0){
                
                    for(int bloe = 0; bloe < characterType.enemy.bucklesOuter.Length; bloe++) {

                        characterType.enemy.bucklesOuter[bloe].holder.SetActive(false);

                    }//for bloe enemy.bucklesOuter 

                    characterType.enemy.bucklesOuter[type - 1].holder.SetActive(true);
                
                }//bucklesOuter.Length > 0
                    
                if(characterType.enemy.referencesUI.bucklesOuter.material != null){
                    
                    characterType.enemy.referencesUI.bucklesOuter.material.interactable = true;
                
                }//bucklesOuter.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.bucklesOuter.Length > 0){
                
                    for(int blo = 0; blo < characterType.player.bucklesOuter.Length; blo++) {

                        characterType.player.bucklesOuter[blo].holder.SetActive(false);

                    }//for blo player.bucklesOuter
                
                }//bucklesOuter.Length > 0
                    
                if(characterType.player.referencesUI.bucklesOuter.material != null){
                    
                    characterType.player.referencesUI.bucklesOuter.material.interactable = false;
            
                }//bucklesOuter.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.bucklesOuter.Length > 0){
                
                    for(int bloe = 0; bloe < characterType.enemy.bucklesOuter.Length; bloe++) {

                        characterType.enemy.bucklesOuter[bloe].holder.SetActive(false);

                    }//for bloe enemy.bucklesOuter    
                
                }//bucklesOuter.Length > 0
                    
                if(characterType.enemy.referencesUI.bucklesOuter.material != null){
                    
                    characterType.enemy.referencesUI.bucklesOuter.material.interactable = false;
            
                }//bucklesOuter.material != null
                
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//BucklesOuter_Set
    
    
////////////////////
///
///     COLLARS SET
///
////////////////////
    
    
    public void Collars_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.collars.Length > 0){
                
                    for(int col = 0; col < characterType.player.collars.Length; col++) {

                        characterType.player.collars[col].holder.SetActive(false);

                    }//for col player.collars 

                    characterType.player.collars[type - 1].holder.SetActive(true);
                
                }//collars.Length > 0
                    
                if(characterType.player.referencesUI.collars.material != null){
                    
                    characterType.player.referencesUI.collars.material.interactable = true;
                
                }//collars.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.collars.Length > 0){
                
                    for(int col = 0; col < characterType.enemy.collars.Length; col++) {

                        characterType.enemy.collars[col].holder.SetActive(false);

                    }//for col player.collars 

                    characterType.enemy.collars[type - 1].holder.SetActive(true);
                
                }//collars.Length > 0
                    
                if(characterType.enemy.referencesUI.collars.material != null){
                    
                    characterType.enemy.referencesUI.collars.material.interactable = true;
                
                }//collars.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.collars.Length > 0){
                
                    for(int col = 0; col < characterType.player.collars.Length; col++) {

                        characterType.player.collars[col].holder.SetActive(false);

                    }//for col player.collars 
                
                }//collars.Length > 0
                    
                if(characterType.player.referencesUI.collars.material != null){
                    
                    characterType.player.referencesUI.collars.material.interactable = false;
            
                }//collars.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.collars.Length > 0){
                
                    for(int col = 0; col < characterType.enemy.collars.Length; col++) {

                        characterType.enemy.collars[col].holder.SetActive(false);

                    }//for col player.collars 
                
                }//collars.Length > 0
                    
                if(characterType.enemy.referencesUI.collars.material != null){
                    
                    characterType.enemy.referencesUI.collars.material.interactable = false;
            
                }//collars.material != null
                
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//Collars_Set
    
    
////////////////////
///
///     CLOTHS INNER SET
///
////////////////////
    
    
    public void ClothsInner_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.clothsInner.Length > 0){
                
                    for(int cli = 0; cli < characterType.player.clothsInner.Length; cli++) {

                        characterType.player.clothsInner[cli].holder.SetActive(false);

                    }//for cli player.clothsInner 

                    characterType.player.clothsInner[type - 1].holder.SetActive(true);
                
                }//clothsInner.Length > 0
                    
                if(characterType.player.referencesUI.clothsInner.material != null){
                    
                    characterType.player.referencesUI.clothsInner.material.interactable = true;
                
                }//clothsInner.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.clothsInner.Length > 0){
                
                    for(int cli = 0; cli < characterType.enemy.clothsInner.Length; cli++) {

                        characterType.enemy.clothsInner[cli].holder.SetActive(false);

                    }//for cli player.clothsInner 

                    characterType.enemy.clothsInner[type - 1].holder.SetActive(true);
                
                }//clothsInner.Length > 0
                    
                if(characterType.enemy.referencesUI.clothsInner.material != null){
                    
                    characterType.enemy.referencesUI.clothsInner.material.interactable = true;
                
                }//clothsInner.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.clothsInner.Length > 0){
                
                    for(int cli = 0; cli < characterType.player.clothsInner.Length; cli++) {

                        characterType.player.clothsInner[cli].holder.SetActive(false);

                    }//for cli player.clothsInner      
                
                }//clothsInner.Length > 0
                    
                if(characterType.player.referencesUI.clothsInner.material != null){
                    
                    characterType.player.referencesUI.clothsInner.material.interactable = false;
            
                }//clothsInner.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.clothsInner.Length > 0){
                
                    for(int cli = 0; cli < characterType.enemy.clothsInner.Length; cli++) {

                        characterType.enemy.clothsInner[cli].holder.SetActive(false);

                    }//for cli player.clothsInner    
                
                }//clothsInner.Length > 0
                    
                if(characterType.enemy.referencesUI.clothsInner.material != null){
                    
                    characterType.enemy.referencesUI.clothsInner.material.interactable = false;
            
                }//clothsInner.material != null
                
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//ClothsInner_Set
    
    
////////////////////
///
///     CLOTHS OUTER SET
///
////////////////////
    
    
    public void ClothsOuter_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.clothsOuter.Length > 0){
                
                    for(int clo = 0; clo < characterType.player.clothsOuter.Length; clo++) {

                        characterType.player.clothsOuter[clo].holder.SetActive(false);

                    }//for clo player.clothsOuter 

                    characterType.player.clothsOuter[type - 1].holder.SetActive(true);
                
                }//clothsOuter.Length > 0
                    
                if(characterType.player.referencesUI.clothsOuter.material != null){
                    
                    characterType.player.referencesUI.clothsOuter.material.interactable = true;
                
                }//clothsOuter.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.clothsOuter.Length > 0){
                
                    for(int clo = 0; clo < characterType.enemy.clothsOuter.Length; clo++) {

                        characterType.enemy.clothsOuter[clo].holder.SetActive(false);

                    }//for clo player.clothsOuter 

                    characterType.enemy.clothsOuter[type - 1].holder.SetActive(true);
                
                }//clothsOuter.Length > 0
                    
                if(characterType.enemy.referencesUI.clothsOuter.material != null){
                    
                    characterType.enemy.referencesUI.clothsOuter.material.interactable = true;
                
                }//clothsOuter.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.clothsOuter.Length > 0){
                
                    for(int clo = 0; clo < characterType.player.clothsOuter.Length; clo++) {

                        characterType.player.clothsOuter[clo].holder.SetActive(false);

                    }//for clo player.clothsOuter    
                    
                }//clothsOuter.Length > 0
                
                if(characterType.player.referencesUI.clothsOuter.material != null){
                    
                    characterType.player.referencesUI.clothsOuter.material.interactable = false;
                
                }//clothsOuter.material != null
            
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.clothsOuter.Length > 0){
                
                    for(int clo = 0; clo < characterType.enemy.clothsOuter.Length; clo++) {

                        characterType.enemy.clothsOuter[clo].holder.SetActive(false);

                    }//for clo player.clothsOuter   
                    
                }//clothsOuter.Length > 0
                
                if(characterType.enemy.referencesUI.clothsOuter.material != null){
                    
                    characterType.enemy.referencesUI.clothsOuter.material.interactable = false;
                
                }//clothsOuter.material != null
            
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//ClothsOuter_Set
    
    
////////////////////
///
///     HORNS SET
///
////////////////////
    
    
    public void Horns_Set(int type){
        
        if(type > 0){
            
            if(charTypeCurrent == CharType_Current.Player){
                
                if(characterType.player.horns.Length > 0){
                
                    for(int hrn = 0; hrn < characterType.player.horns.Length; hrn++) {

                        characterType.player.horns[hrn].holder.SetActive(false);

                    }//for hrn player.horns 

                    characterType.player.horns[type - 1].holder.SetActive(true);
                
                }//horns.Length > 0
                    
                if(characterType.player.referencesUI.horns.material != null){
                    
                    characterType.player.referencesUI.horns.material.interactable = true;
                
                }//horns.material != null
                
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
                
                if(characterType.enemy.horns.Length > 0){
                
                    for(int hrn = 0; hrn < characterType.enemy.horns.Length; hrn++) {

                        characterType.enemy.horns[hrn].holder.SetActive(false);

                    }//for hrn player.horns 

                    characterType.enemy.horns[type - 1].holder.SetActive(true);
                
                }//horns.Length > 0
                    
                if(characterType.enemy.referencesUI.horns.material != null){
                    
                    characterType.enemy.referencesUI.horns.material.interactable = true;
                
                }//horns.material != null
                
            }//charTypeCurrent = enemy
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.horns.Length > 0){
                
                    for(int hrn = 0; hrn < characterType.player.horns.Length; hrn++) {

                        characterType.player.horns[hrn].holder.SetActive(false);

                    }//for hrn player.horns       
                
                }//horns.Length > 0
                    
                if(characterType.player.referencesUI.horns.material != null){
                    
                    characterType.player.referencesUI.horns.material.interactable = false;
                
                }//horns.material != null
            
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.horns.Length > 0){
                
                    for(int hrn = 0; hrn < characterType.enemy.horns.Length; hrn++) {

                        characterType.enemy.horns[hrn].holder.SetActive(false);

                    }//for hrn player.horns   
                    
                }//horns.Length > 0
                
                if(characterType.enemy.referencesUI.horns.material != null){
                    
                    characterType.enemy.referencesUI.horns.material.interactable = false;
                
                }//horns.material != null
            
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//Horns_Set
    
    
////////////////////
///
///     SHOULDER PADS SET
///
////////////////////
    
    
    public void ShoulderPads_Set(int type){
        
        if(type > 0){
            
            if(type == 1){
             
                if(charTypeCurrent == CharType_Current.Player){

                    if(characterType.player.shoulderPads.Length > 0){
                    
                        for(int shpd = 0; shpd < characterType.player.shoulderPads.Length; shpd++) {

                            characterType.player.shoulderPads[shpd].holder.SetActive(true);

                        }//for shpd player.shoulderPads 
                        
                    }//shoulderPads.Length > 0
                    
                    if(characterType.player.referencesUI.shoulderPads.material != null){
                        
                        characterType.player.referencesUI.shoulderPads.material.interactable = true;

                    }//shoulderPads.material != null
                    
                }//charTypeCurrent = player

                if(charTypeCurrent == CharType_Current.Enemy){
                    
                    if(characterType.enemy.shoulderPads.Length > 0){

                        for(int shpd = 0; shpd < characterType.enemy.shoulderPads.Length; shpd++) {

                            characterType.enemy.shoulderPads[shpd].holder.SetActive(true);

                        }//for shpd player.shoulderPads 
                        
                    }//shoulderPads.Length > 0
                    
                    if(characterType.enemy.referencesUI.shoulderPads.material != null){
                        
                        characterType.enemy.referencesUI.shoulderPads.material.interactable = true;

                    }//shoulderPads.material != null
                    
                }//charTypeCurrent = enemy
                
            //type = both
            } else {
            
                if(charTypeCurrent == CharType_Current.Player){

                    if(characterType.player.shoulderPads.Length > 0){
                    
                        for(int shpd = 0; shpd < characterType.player.shoulderPads.Length; shpd++) {

                            characterType.player.shoulderPads[shpd].holder.SetActive(false);

                        }//for shpd player.shoulderPads 

                        characterType.player.shoulderPads[type - 2].holder.SetActive(true);
                    
                    }//shoulderPads.Length > 0
                        
                    if(characterType.player.referencesUI.shoulderPads.material != null){
                        
                        characterType.player.referencesUI.shoulderPads.material.interactable = true;

                    }//shoulderPads.material != null

                }//charTypeCurrent = player

                if(charTypeCurrent == CharType_Current.Enemy){

                    if(characterType.enemy.shoulderPads.Length > 0){
                    
                        for(int shpd = 0; shpd < characterType.enemy.shoulderPads.Length; shpd++) {

                            characterType.enemy.shoulderPads[shpd].holder.SetActive(false);

                        }//for shpd player.shoulderPads 

                        characterType.enemy.shoulderPads[type - 2].holder.SetActive(true);
                    
                    }//shoulderPads.Length > 0
                        
                    if(characterType.enemy.referencesUI.shoulderPads.material != null){
                        
                        characterType.enemy.referencesUI.shoulderPads.material.interactable = true;

                    }//shoulderPads.material != null

                }//charTypeCurrent = enemy
                
            }//type = both
            
        //type > 0
        } else {
            
            if(charTypeCurrent == CharType_Current.Player){
            
                if(characterType.player.shoulderPads.Length > 0){
                
                    for(int shpd = 0; shpd < characterType.player.shoulderPads.Length; shpd++) {

                        characterType.player.shoulderPads[shpd].holder.SetActive(false);

                    }//for shpd player.horns     
                    
                }//shoulderPads.Length > 0
                
                if(characterType.player.referencesUI.shoulderPads.material != null){
                        
                    characterType.player.referencesUI.shoulderPads.material.interactable = false;

                }//shoulderPads.material != null
            
            }//charTypeCurrent = player
            
            if(charTypeCurrent == CharType_Current.Enemy){
            
                if(characterType.enemy.shoulderPads.Length > 0){
                
                    for(int shpd = 0; shpd < characterType.enemy.shoulderPads.Length; shpd++) {

                        characterType.enemy.shoulderPads[shpd].holder.SetActive(false);

                    }//for shpd player.shoulderPads       
                
                }//shoulderPads.Length > 0
                    
                if(characterType.enemy.referencesUI.shoulderPads.material != null){
                        
                    characterType.enemy.referencesUI.shoulderPads.material.interactable = false;

                }//shoulderPads.material != null
            
            }//charTypeCurrent = enemy
                
        }//type > 0
        
    }//ShoulderPads_Set
    
    
//////////////////////////////
///
///     MATERIAL SET
///
//////////////////////////////
    
///////////////////////
///
///     MAIN BODY
///
///////////////////////
    
/////////////////
///
///     HEAD
///
/////////////////
    
    
    public void MaterialSet_Head(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Head"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Head"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Head
    
    
/////////////////
///
///     NECK
///
/////////////////
    
    
    public void MaterialSet_Neck(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Neck"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Neck"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Neck
    
    
/////////////////
///
///     EYES
///
/////////////////
    
    
    public void MaterialSet_Eyes(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Eyes"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Eyes"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Eyes
    
    
/////////////////
///
///     TORSO
///
/////////////////
    
    
    public void MaterialSet_Torso(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Torso"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
            
            }//mainBody.Length > 0
                
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Torso"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Torso
    
    
/////////////////
///
///     PELVIS
///
/////////////////
    
    
    public void MaterialSet_Pelvis(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Pelvis"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Pelvis"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Pelvis

    
/////////////////
///
///     HANDS
///
/////////////////
    
    
    public void MaterialSet_Hands(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Hands"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Hands"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Hands
    
    
/////////////////
///
///     FEET
///
/////////////////
    
    
    public void MaterialSet_Feet(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Feet"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Feet"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Feet
    
    
/////////////////
///
///     LEGS
///
/////////////////
    
    
    public void MaterialSet_Legs(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Legs"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Legs"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Legs
    
    
/////////////////
///
///     LEGS UPPER
///
/////////////////
    
    
    public void MaterialSet_LegsUpper(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            if(characterType.player.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {

                    if(characterType.player.mainBody[mb].name == "Legs Upper"){

                        Material[] mats = characterType.player.mainBody[mb].mesh.materials;

                        mats[0] = characterType.player.mainBody[mb].materials[slot];

                        characterType.player.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.player.mainBody[mb].dropdown.value != slot){
                        
                            characterType.player.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb player.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            if(characterType.enemy.mainBody.Length > 0){
            
                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {

                    if(characterType.enemy.mainBody[mb].name == "Legs Upper"){

                        Material[] mats = characterType.enemy.mainBody[mb].mesh.materials;

                        mats[0] = characterType.enemy.mainBody[mb].materials[slot];

                        characterType.enemy.mainBody[mb].mesh.materials = mats;
                        
                        if(characterType.enemy.mainBody[mb].dropdown.value != slot){
                        
                            characterType.enemy.mainBody[mb].dropdown.value = slot;
                            
                        }//dropdown.value != slot

                    }//name = head

                }//for mb enemy.mainBody 
                
            }//mainBody.Length > 0
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_LegsUpper
    
    
///////////////////////
///
///     BODY PIECES
///
///////////////////////

/////////////////
///
///     BELT
///
/////////////////
    
    
    public void MaterialSet_Belt(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.belts[characterType.player.referencesUI.belts.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.belts[characterType.player.referencesUI.belts.part.value - 1].materials[slot];
            
            characterType.player.belts[characterType.player.referencesUI.belts.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.belts[characterType.enemy.referencesUI.belts.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.belts[characterType.enemy.referencesUI.belts.part.value - 1].materials[slot];
            
            characterType.enemy.belts[characterType.enemy.referencesUI.belts.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Belt
    
    
/////////////////
///
///     BROWS
///
/////////////////
    
    
    public void MaterialSet_Brows(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.brows[characterType.player.referencesUI.brows.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.brows[characterType.player.referencesUI.brows.part.value - 1].materials[slot];
            
            characterType.player.brows[characterType.player.referencesUI.brows.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.brows[characterType.enemy.referencesUI.brows.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.brows[characterType.enemy.referencesUI.brows.part.value - 1].materials[slot];
            
            characterType.enemy.brows[characterType.enemy.referencesUI.brows.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Brows
    
    
/////////////////
///
///     BUCKLES INNER
///
/////////////////
    
    
    public void MaterialSet_BucklesInner(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.bucklesInner[characterType.player.referencesUI.bucklesInner.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.bucklesInner[characterType.player.referencesUI.bucklesInner.part.value - 1].materials[slot];
            
            characterType.player.bucklesInner[characterType.player.referencesUI.bucklesInner.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.bucklesInner[characterType.enemy.referencesUI.bucklesInner.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.bucklesInner[characterType.enemy.referencesUI.bucklesInner.part.value - 1].materials[slot];
            
            characterType.enemy.bucklesInner[characterType.enemy.referencesUI.bucklesInner.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_BucklesInner

    
/////////////////
///
///     BUCKLES OUTER
///
/////////////////
    
    
    public void MaterialSet_BucklesOuter(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.bucklesOuter[characterType.player.referencesUI.bucklesOuter.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.bucklesOuter[characterType.player.referencesUI.bucklesOuter.part.value - 1].materials[slot];
            
            characterType.player.bucklesOuter[characterType.player.referencesUI.bucklesOuter.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.bucklesOuter[characterType.enemy.referencesUI.bucklesOuter.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.bucklesOuter[characterType.enemy.referencesUI.bucklesOuter.part.value - 1].materials[slot];
            
            characterType.enemy.bucklesOuter[characterType.enemy.referencesUI.bucklesOuter.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_BucklesOuter
    
    
/////////////////
///
///     COLLAR
///
/////////////////
    
    
    public void MaterialSet_Collar(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.collars[characterType.player.referencesUI.collars.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.collars[characterType.player.referencesUI.collars.part.value - 1].materials[slot];
            
            characterType.player.collars[characterType.player.referencesUI.collars.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.collars[characterType.enemy.referencesUI.collars.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.collars[characterType.enemy.referencesUI.collars.part.value - 1].materials[slot];
            
            characterType.enemy.collars[characterType.enemy.referencesUI.collars.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Collar
    
    
/////////////////
///
///     CLOTHS INNER
///
/////////////////
    
    
    public void MaterialSet_ClothsInner(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.clothsInner[characterType.player.referencesUI.clothsInner.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.clothsInner[characterType.player.referencesUI.clothsInner.part.value - 1].materials[slot];
            
            characterType.player.clothsInner[characterType.player.referencesUI.clothsInner.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.clothsInner[characterType.enemy.referencesUI.clothsInner.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.clothsInner[characterType.enemy.referencesUI.clothsInner.part.value - 1].materials[slot];
            
            characterType.enemy.clothsInner[characterType.enemy.referencesUI.clothsInner.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_ClothsInner
    
    
/////////////////
///
///     CLOTHS OUTER
///
/////////////////
    
    
    public void MaterialSet_ClothsOuter(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.clothsOuter[characterType.player.referencesUI.clothsOuter.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.clothsOuter[characterType.player.referencesUI.clothsOuter.part.value - 1].materials[slot];
            
            characterType.player.clothsOuter[characterType.player.referencesUI.clothsOuter.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.clothsOuter[characterType.enemy.referencesUI.clothsOuter.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.clothsOuter[characterType.enemy.referencesUI.clothsOuter.part.value - 1].materials[slot];
            
            characterType.enemy.clothsOuter[characterType.enemy.referencesUI.clothsOuter.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_ClothsOuter
    
    
/////////////////
///
///     HORNS
///
/////////////////
    
    
    public void MaterialSet_Horns(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            Material[] mats = characterType.player.horns[characterType.player.referencesUI.horns.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.player.horns[characterType.player.referencesUI.horns.part.value - 1].materials[slot];
            
            characterType.player.horns[characterType.player.referencesUI.horns.part.value - 1].mesh.materials = mats;
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            Material[] mats = characterType.enemy.horns[characterType.enemy.referencesUI.horns.part.value - 1].mesh.materials;
                    
            mats[0] = characterType.enemy.horns[characterType.enemy.referencesUI.horns.part.value - 1].materials[slot];
            
            characterType.enemy.horns[characterType.enemy.referencesUI.horns.part.value - 1].mesh.materials = mats; 
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_Horns
    
    
/////////////////
///
///     SHOULDER PADS
///
/////////////////
    
    
    public void MaterialSet_ShoulderPads(int slot){
        
        if(charTypeCurrent == CharType_Current.Player){
        
            if(characterType.player.referencesUI.shoulderPads.part.value > 1){
            
                Material[] mats = characterType.player.shoulderPads[characterType.player.referencesUI.shoulderPads.part.value - 2].mesh.materials;

                mats[0] = characterType.player.shoulderPads[characterType.player.referencesUI.shoulderPads.part.value - 2].materials[slot];

                for(int shpds = 0; shpds < characterType.player.shoulderPads.Length; shpds++) {
                    
                    characterType.player.shoulderPads[shpds].mesh.materials = mats; 
                    
                }//for shpds shoulderPads
            
            //shoulderPads.part.value > 1
            } else {
            
                if(characterType.player.referencesUI.shoulderPads.part.value == 1){
                
                    Material[] mats = characterType.player.shoulderPads[characterType.player.referencesUI.shoulderPads.part.value - 1].mesh.materials;

                    mats[0] = characterType.player.shoulderPads[characterType.player.referencesUI.shoulderPads.part.value - 1].materials[slot];

                    for(int shpds = 0; shpds < characterType.player.shoulderPads.Length; shpds++) {
                    
                        characterType.player.shoulderPads[shpds].mesh.materials = mats; 
                    
                    }//for shpds shoulderPads
                
                }//shoulderPads.part.value = 1
            
            }//shoulderPads.part.value > 1
            
        }//charTypeCurrent = player
        
        if(charTypeCurrent == CharType_Current.Enemy){
        
            if(characterType.enemy.referencesUI.shoulderPads.part.value > 1){
            
                Material[] mats = characterType.enemy.shoulderPads[characterType.enemy.referencesUI.shoulderPads.part.value - 2].mesh.materials;

                mats[0] = characterType.enemy.shoulderPads[characterType.enemy.referencesUI.shoulderPads.part.value - 2].materials[slot];

                for(int shpdse = 0; shpdse < characterType.enemy.shoulderPads.Length; shpdse++) {
                    
                    characterType.enemy.shoulderPads[shpdse].mesh.materials = mats; 
                    
                }//for shpdse shoulderPads 
            
            //shoulderPads.part.value > 1
            } else {
            
                if(characterType.enemy.referencesUI.shoulderPads.part.value == 1){
                
                    Material[] mats = characterType.enemy.shoulderPads[characterType.enemy.referencesUI.shoulderPads.part.value - 1].mesh.materials;

                    mats[0] = characterType.enemy.shoulderPads[characterType.enemy.referencesUI.shoulderPads.part.value - 1].materials[slot];

                    for(int shpdse = 0; shpdse < characterType.enemy.shoulderPads.Length; shpdse++) {

                        characterType.enemy.shoulderPads[shpdse].mesh.materials = mats; 

                    }//for shpdse shoulderPads  
                
                }//shoulderPads.part.value = 1
            
            }//shoulderPads.part.value > 1
            
        }//charTypeCurrent = enemy
        
    }//MaterialSet_ShoulderPads
    
    
//////////////////////////////////////
///
///     CHARACTER ACTIONS
///
///////////////////////////////////////
    
//////////////////////////////
///
///     CHARACTER SET
///
//////////////////////////////
    
    
    public void CharacterType_Set(int type){
        
        Belt_Set(0);
        EyeBrow_Set(0);
        BucklesInner_Set(0);
        BucklesOuter_Set(0);
        Collars_Set(0);
        ClothsInner_Set(0);
        ClothsOuter_Set(0);
        Horns_Set(0);
        ShoulderPads_Set(0);
        
        if(type == 0){
            
            charTypeCurrent = CharType_Current.Player;
            
            characterType.enemy.referencesUI.mainBodyHolder.SetActive(false);
            characterType.enemy.referencesUI.bodyPiecesHolder.SetActive(false);
            
            characterType.player.referencesUI.mainBodyHolder.SetActive(true);
            characterType.player.referencesUI.bodyPiecesHolder.SetActive(true);
            
        }//type = player
        
        if(type == 1){
            
            charTypeCurrent = CharType_Current.Enemy;
            
            characterType.enemy.referencesUI.mainBodyHolder.SetActive(true);
            characterType.enemy.referencesUI.bodyPiecesHolder.SetActive(true);
            
            characterType.player.referencesUI.mainBodyHolder.SetActive(false);
            characterType.player.referencesUI.bodyPiecesHolder.SetActive(false);
            
        }//type = enemy
        
        StartCoroutine("DefaultsBuff");
        
    }//CharacterType_Set
    
    
//////////////////////////////
///
///     CHARACTER DEFAULTS SET
///
//////////////////////////////
    
    
    private IEnumerator DefaultsBuff(){
    
        yield return new WaitForSeconds(0.05f);
    
        DefaultsSet_Check();
    
    }//DefaultsBuff
    
    public void DefaultsSet_Check(){
        
        if(charTypeCurrent == CharType_Current.Player){
            
            DefaultsSet_Player();
            
        }//charTypeCurrent = enemy        
        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            DefaultsSet_Enemy();
            
        }//charTypeCurrent = enemy
        
    }//DefaultsSet_Check
    
    public void DefaultsSet_Player(){
        
        //Debug.Log("Player Defaults Set");
        
        characterType.player.referencesUI.belts.part.value = 1;
        characterType.player.referencesUI.belts.material.value = 0;
        
        characterType.player.referencesUI.brows.part.value = 1;
        characterType.player.referencesUI.brows.material.value = 1;
        
        characterType.player.referencesUI.bucklesInner.part.value = 1;
        characterType.player.referencesUI.bucklesInner.material.value = 0;
        
        characterType.player.referencesUI.bucklesOuter.part.value = 2;
        characterType.player.referencesUI.bucklesOuter.material.value = 1;
        
        characterType.player.referencesUI.collars.part.value = 2;
        characterType.player.referencesUI.collars.material.value = 0;
        
        characterType.player.referencesUI.clothsInner.part.value = 1;
        characterType.player.referencesUI.clothsInner.material.value = 0;
        
        characterType.player.referencesUI.clothsOuter.part.value = 1;
        characterType.player.referencesUI.clothsOuter.material.value = 0;
        
        characterType.player.referencesUI.shoulderPads.part.value = 2;
        characterType.player.referencesUI.shoulderPads.material.value = 0;
        
        Belt_Set(1);
        EyeBrow_Set(1);
        BucklesInner_Set(1);
        BucklesOuter_Set(2);
        Collars_Set(2);
        ClothsInner_Set(1);
        ClothsOuter_Set(1);
        ShoulderPads_Set(2);
        
        MaterialSet_Belt(0);
        MaterialSet_Brows(1);
        MaterialSet_BucklesInner(0);
        MaterialSet_BucklesOuter(1);
        MaterialSet_Collar(0);
        MaterialSet_ClothsInner(0);
        MaterialSet_ClothsOuter(0);
        MaterialSet_ShoulderPads(0);
        
        MaterialSet_Head(0);
        MaterialSet_Neck(0);
        MaterialSet_Eyes(0);
        MaterialSet_Torso(0);
        MaterialSet_Pelvis(0);
        MaterialSet_Hands(0);
        MaterialSet_Feet(0);
        MaterialSet_Legs(0);
        MaterialSet_LegsUpper(0);
        
    }//DefaultsSet_Player
    
    public void DefaultsSet_Enemy(){
        
        //Debug.Log("Enemy Defaults Set");
        
        characterType.enemy.referencesUI.belts.part.value = 2;
        characterType.enemy.referencesUI.belts.material.value = 0;
        
        characterType.enemy.referencesUI.brows.part.value = 1;
        characterType.enemy.referencesUI.brows.material.value = 0;
        
        characterType.enemy.referencesUI.bucklesOuter.part.value = 1;
        characterType.enemy.referencesUI.bucklesOuter.material.value = 1;
        
        characterType.enemy.referencesUI.clothsInner.part.value = 2;
        characterType.enemy.referencesUI.clothsInner.material.value = 1;
        
        characterType.enemy.referencesUI.clothsOuter.part.value = 1;
        characterType.enemy.referencesUI.clothsOuter.material.value = 0;
        
        characterType.enemy.referencesUI.horns.part.value = 2;
        characterType.enemy.referencesUI.horns.material.value = 1;
        
        characterType.enemy.referencesUI.shoulderPads.part.value = 2;
        characterType.enemy.referencesUI.shoulderPads.material.value = 0;
        
        Belt_Set(2);
        EyeBrow_Set(1);
        BucklesOuter_Set(1);
        ClothsInner_Set(2);
        ClothsOuter_Set(1);
        Horns_Set(2);
        ShoulderPads_Set(2);
        
        MaterialSet_Belt(0);
        MaterialSet_Brows(0);
        MaterialSet_BucklesOuter(1);
        MaterialSet_ClothsInner(1);
        MaterialSet_ClothsOuter(0);
        MaterialSet_Horns(1);
        MaterialSet_ShoulderPads(0);
        
        MaterialSet_Head(1);
        MaterialSet_Neck(1);
        MaterialSet_Eyes(0);
        MaterialSet_Torso(1);
        MaterialSet_Pelvis(1);
        MaterialSet_Hands(1);
        MaterialSet_Feet(1);
        MaterialSet_Legs(1);
        MaterialSet_LegsUpper(1);
        
    }//DefaultsSet_Enemy
    
    
//////////////////////////////
///
///     CHARACTER RANDOMIZE
///
//////////////////////////////
    
    
    public void Character_Randomize(){
        
        tempBelt = -1;
        tempBeltChance = -1;
        tempBeltMat = -1;
        
        tempBrow = -1;
        tempBrowMat = -1;
        
        tempBuckInner = -1;
        tempBuckInnerChance = -1;
        tempBuckInnerMat = -1;
        
        tempBuckOuter = -1;
        tempBuckOuterChance = -1;
        tempBuckOuterMat = -1;
        
        tempCollar = -1;
        tempCollarChance = -1;
        tempCollarMat = -1;
        
        tempClothInner = -1;
        tempClothInnerChance = -1;
        tempClothInnerMat = -1;
        
        tempClothOuter = -1;
        tempClothOuterChance = -1;
        tempClothOuterMat = -1;
        
        tempHorns = -1;
        tempHornsChance = -1;
        tempHornsMat = -1;
        
        tempShouldPad = -1;
        tempShouldPadsChance = -1;
        tempShouldPadMat = -1;
        
        tempHeadMat = -1;
        tempNeckMat = -1;
        tempEyesMat = -1;
        tempTorsoMat = -1;
        tempPelvisMat = -1;
        tempHandsMat = -1;
        tempFeetMat = -1;
        tempLegsMat = -1;
        tempLegsUpperMat = -1;
        
        
/////////////////////////////
///
///     PLAYER
///
/////////////////////////////
        
        
        if(charTypeCurrent == CharType_Current.Player){
            
            
///////////////////////
///
///     BODY PIECES
///
///////////////////////
            
////////////////
///
///     BELTS
///
////////////////
            
            
            if(characterType.player.belts.Length > 0){
                
                tempBeltChance = Random.Range(0, 2);
                
                if(tempBeltChance == 1){
                
                    if(characterType.player.belts.Length > 1){

                        tempBelt = Random.Range(0, characterType.player.belts.Length);
                        tempBeltMat = Random.Range(0, characterType.player.belts[tempBelt].materials.Length);
                        
                        characterType.player.referencesUI.belts.part.value = tempBelt + 1;
                        characterType.player.referencesUI.belts.material.value = tempBeltMat;
                        
                    //tempBeltChance = 1
                    } else {
                    
                        tempBeltMat = Random.Range(0, characterType.player.belts[0].materials.Length);

                        characterType.player.referencesUI.belts.part.value = 1;
                        characterType.player.referencesUI.belts.material.value = tempBeltMat;

                    }//tempBeltChance = 1
                    
                //tempBeltChance = active
                } else {
                
                    characterType.player.referencesUI.belts.part.value = 0;
                
                }//tempBeltChance = active
                
            }//player.belts.Length > 0

            
////////////////
///
///     BROWS
///
////////////////
            

            if(characterType.player.brows.Length > 0){

                if(characterType.player.brows.Length > 1){

                    tempBrow = Random.Range(0, characterType.player.brows.Length);
                    tempBrowMat = Random.Range(0, characterType.player.brows[tempBrow].materials.Length);
                    
                    characterType.player.referencesUI.brows.part.value = tempBrow + 1;
                    characterType.player.referencesUI.brows.material.value = tempBrowMat;

                //player.brows.Length > 1
                } else {

                    tempBrowMat = Random.Range(0, characterType.player.brows[0].materials.Length);

                    characterType.player.referencesUI.brows.part.value = 1;
                    characterType.player.referencesUI.brows.material.value = tempBrowMat;

                }//player.brows.Length > 1
                
            }//player.brows.Length > 0
            

////////////////
///
///     BUCKLES OUTER
///
////////////////
            
            
            if(characterType.player.bucklesOuter.Length > 0){
                
                if(tempBeltChance > 0){
                
                    tempBuckOuterChance = Random.Range(0, 2);
                
                    if(tempBuckOuterChance == 1){

                        if(characterType.player.bucklesOuter.Length > 1){

                            tempBuckOuter = Random.Range(0, characterType.player.bucklesOuter.Length);
                            tempBuckOuterMat = Random.Range(0, characterType.player.bucklesOuter[tempBuckOuter].materials.Length);

                            characterType.player.referencesUI.bucklesOuter.part.value = tempBuckOuter + 1;
                            characterType.player.referencesUI.bucklesOuter.material.value = tempBuckOuterMat;

                        //player.bucklesOuter.Length > 1
                        } else {

                            tempBuckOuterMat = Random.Range(0, characterType.player.bucklesOuter[0].materials.Length);

                            characterType.player.referencesUI.bucklesOuter.part.value = 1;
                            characterType.player.referencesUI.bucklesOuter.material.value = tempBuckOuterMat;

                        }//player.bucklesOuter.Length > 1

                    //tempBuckOuterChance = active
                    } else {
                    
                        characterType.player.referencesUI.bucklesOuter.part.value = 0;
                    
                    }//tempBuckOuterChance = active
                
                //tempBeltChance > 0
                } else {
                
                    characterType.player.referencesUI.bucklesOuter.part.value = 0;
                
                }//tempBeltChance > 0
                
            }//player.bucklesOuter.Length > 0
            
            
////////////////
///
///     BUCKLES INNER
///
////////////////
            
            
            if(characterType.player.bucklesInner.Length > 0){
                
                if(tempBeltChance > 0 && tempBuckOuterChance > 0){
                
                    tempBuckInnerChance = Random.Range(0, 2);
                
                    if(tempBuckInnerChance == 1){

                        if(characterType.player.bucklesInner.Length > 1){

                            tempBuckInner = Random.Range(0, characterType.player.bucklesInner.Length);
                            tempBuckInnerMat = Random.Range(0, characterType.player.bucklesInner[tempBuckInner].materials.Length);

                            characterType.player.referencesUI.bucklesInner.part.value = tempBuckInner + 1;
                            characterType.player.referencesUI.bucklesInner.material.value = tempBuckInnerMat;

                        //player.bucklesInner.Length > 1
                        } else {

                            tempBuckInnerMat = Random.Range(0, characterType.player.bucklesInner[0].materials.Length);

                            characterType.player.referencesUI.bucklesInner.part.value = 1;
                            characterType.player.referencesUI.bucklesInner.material.value = tempBuckInnerMat;

                        }//player.bucklesInner.Length > 1

                    //tempBuckInnerChance = active
                    } else {
                    
                        characterType.player.referencesUI.bucklesInner.part.value = 0;
                    
                    }//tempBuckInnerChance = active
                
                //tempBeltChance > 0 & tempBuckOuterChance > 0
                } else {
                
                    characterType.player.referencesUI.bucklesInner.part.value = 0;
                
                }//tempBeltChance > 0 & tempBuckOuterChance > 0
                
            }//player.bucklesInner.Length > 0
            
            
////////////////
///
///     COLLARS
///
////////////////
            
            
            if(characterType.player.collars.Length > 0){
                
                tempCollarChance = Random.Range(0, 2);
                
                if(tempCollarChance == 1){
                
                    if(characterType.player.collars.Length > 1){

                        tempCollar = Random.Range(0, characterType.player.collars.Length);
                        tempCollarMat = Random.Range(0, characterType.player.collars[tempCollar].materials.Length);

                        characterType.player.referencesUI.collars.part.value = tempCollar + 1;
                        characterType.player.referencesUI.collars.material.value = tempCollarMat;

                    //player.collars.Length > 1
                    } else {

                        tempCollarMat = Random.Range(0, characterType.player.collars[0].materials.Length);

                        characterType.player.referencesUI.collars.part.value = 1;
                        characterType.player.referencesUI.collars.material.value = tempCollarMat;

                    }//player.collars.Length > 1
                
                //tempCollarChance = active
                } else {
                    
                    characterType.player.referencesUI.collars.part.value = 0;
                    
                }//tempCollarChance = active
                
            }//player.collars.Length > 0
            
            
////////////////
///
///     CLOTHS INNER
///
////////////////
            
            
            if(characterType.player.clothsInner.Length > 0){
                
                tempClothInnerChance = Random.Range(0, 2);
                
                if(tempClothInnerChance == 1){
                
                    if(characterType.player.clothsInner.Length > 1){

                        tempClothInner = Random.Range(0, characterType.player.clothsInner.Length);
                        tempClothInnerMat = Random.Range(0, characterType.player.clothsInner[tempClothInner].materials.Length);

                        characterType.player.referencesUI.clothsInner.part.value = tempClothInner + 1;
                        characterType.player.referencesUI.clothsInner.material.value = tempClothInnerMat;

                    //player.clothsInner.Length > 1
                    } else {

                        tempClothInnerMat = Random.Range(0, characterType.player.clothsInner[0].materials.Length);

                        characterType.player.referencesUI.clothsInner.part.value = 1;
                        characterType.player.referencesUI.clothsInner.material.value = tempClothInnerMat;

                    }//player.clothsInner.Length > 1
                    
                //tempClothInnerChance = active
                } else {
                    
                    characterType.player.referencesUI.clothsInner.part.value = 0;
                    
                }//tempClothInnerChance = active
                
            }//player.clothsInner.Length > 0
            
            
////////////////
///
///     CLOTHS OUTER
///
/////////////////
            
            
            if(characterType.player.clothsOuter.Length > 0){
                
                tempClothOuterChance = Random.Range(0, 2);
                
                if(tempClothOuterChance == 1){
                
                    if(characterType.player.clothsOuter.Length > 1){

                        tempClothOuter = Random.Range(0, characterType.player.clothsOuter.Length);
                        tempClothOuterMat = Random.Range(0, characterType.player.clothsOuter[tempClothOuter].materials.Length);

                        characterType.player.referencesUI.clothsOuter.part.value = tempClothOuter + 1;
                        characterType.player.referencesUI.clothsOuter.material.value = tempClothOuterMat;

                    //player.clothsInner.Length > 1
                    } else {

                        tempClothOuterMat = Random.Range(0, characterType.player.clothsOuter[0].materials.Length);

                        characterType.player.referencesUI.clothsOuter.part.value = 1;
                        characterType.player.referencesUI.clothsOuter.material.value = tempClothOuterMat;

                    }//player.clothsOuter.Length > 1
                    
                //tempClothOuterChance = active
                } else {
                    
                    characterType.player.referencesUI.clothsOuter.part.value = 0;
                    
                }//tempClothOuterChance = active
                
            }//player.clothsOuter.Length > 0
            
            
////////////////
///
///     HORNS
///
/////////////////
            
            
            if(characterType.player.horns.Length > 0){
                
                tempHornsChance = Random.Range(0, 2);
                
                if(tempHornsChance == 1){
                
                    if(characterType.player.horns.Length > 1){

                        tempHorns = Random.Range(0, characterType.player.horns.Length);
                        tempHornsMat = Random.Range(0, characterType.player.horns[tempHorns].materials.Length);

                        characterType.player.referencesUI.horns.part.value = tempHorns + 1;
                        characterType.player.referencesUI.horns.material.value = tempHornsMat;

                    //player.horns.Length > 1
                    } else {

                        tempHornsMat = Random.Range(0, characterType.player.horns[0].materials.Length);

                        characterType.player.referencesUI.horns.part.value = 1;
                        characterType.player.referencesUI.horns.material.value = tempHornsMat;

                    }//player.horns.Length > 1
                    
                //tempHornsChance = active
                } else {
                    
                    characterType.player.referencesUI.horns.part.value = 0;
                    
                }//tempHornsChance = active
                
            }//player.horns.Length > 0
            
            
////////////////
///
///     SHOULDER PADS
///
////////////////
            
            
            if(characterType.player.shoulderPads.Length > 0){
                
                tempShouldPadsChance = Random.Range(0, 3);
                
                for(int shp = 0; shp < characterType.player.shoulderPads.Length; shp++) {
                    
                    characterType.player.shoulderPads[shp].holder.SetActive(false);
                                        
                }//for shp player.shoulderPads
                
                if(tempShouldPadsChance == 0){
                
                    characterType.player.referencesUI.shoulderPads.part.value = 0;
                
                }//tempShouldPadsChance = not active
                
                if(tempShouldPadsChance == 1){
                
                    if(characterType.player.shoulderPads.Length > 1){

                        tempShouldPad = Random.Range(0, characterType.player.shoulderPads.Length);
                        tempShouldPadMat = Random.Range(0, characterType.player.shoulderPads[tempShouldPad].materials.Length);

                        characterType.player.referencesUI.shoulderPads.part.value = tempShouldPad + 2;
                        characterType.player.referencesUI.shoulderPads.material.value = tempShouldPadMat;

                    //player.clothsInner.Length > 1
                    } else {

                        tempClothOuterMat = Random.Range(0, characterType.player.shoulderPads[0].materials.Length);

                        characterType.player.referencesUI.shoulderPads.part.value = 2;
                        characterType.player.referencesUI.shoulderPads.material.value = tempClothOuterMat;

                    }//player.shoulderPads.Length > 1
                    
                }//tempShouldPadsChance = single pad
                
                if(tempShouldPadsChance == 2){
                
                    tempShouldPadMat = Random.Range(0, characterType.player.shoulderPads[0].materials.Length);

                    characterType.player.referencesUI.shoulderPads.part.value = 1;
                    characterType.player.referencesUI.shoulderPads.material.value = tempShouldPadMat;
                
                }//tempShouldPadsChance = dual pads pad
                
            }//player.shoulderPads.Length > 0 
            
            
///////////////////////
///
///     BODY
///
///////////////////////
            

            if(characterType.player.mainBody.Length > 0){

                for(int mb = 0; mb < characterType.player.mainBody.Length; mb++) {
            
            
////////////////
///
///     HEAD
///
////////////////
            

                    if(characterType.player.mainBody[mb].name == "Head"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempHeadMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempHeadMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempHeadMat;

                                }//dropdown.value != tempHeadMat

                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0
                        
                    }//name = Head
                
                
////////////////
///
///     NECK
///
////////////////
                
                
                    if(characterType.player.mainBody[mb].name == "Neck"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempNeckMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempNeckMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempNeckMat;

                                }//dropdown.value != tempNeckMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Neck
                
                
////////////////
///
///     EYES
///
////////////////
                
                
                    if(characterType.player.mainBody[mb].name == "Eyes"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempEyesMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempEyesMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempEyesMat;

                                }//dropdown.value != tempEyesMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Eyes
                

////////////////
///
///     TORSO
///
////////////////
                
                
                    if(characterType.player.mainBody[mb].name == "Torso"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempTorsoMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempTorsoMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempTorsoMat;

                                }//dropdown.value != tempTorsoMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Torso
                
                
////////////////
///
///     PELVIS
///
////////////////
                
                
                    if(characterType.player.mainBody[mb].name == "Pelvis"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempPelvisMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempPelvisMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempPelvisMat;

                                }//dropdown.value != tempPelvisMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Pelvis
                
                
////////////////
///
///     HANDS
///
////////////////

                
                    if(characterType.player.mainBody[mb].name == "Hands"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempHandsMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempHandsMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempHandsMat;

                                }//dropdown.value != tempHandsMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Hands
                
                
////////////////
///
///     FEET
///
////////////////

                
                    if(characterType.player.mainBody[mb].name == "Feet"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempFeetMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempFeetMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempFeetMat;

                                }//dropdown.value != tempFeetMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Feet
                
                
////////////////
///
///     LEGS
///
////////////////

                
                    if(characterType.player.mainBody[mb].name == "Legs"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempLegsMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempLegsMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempLegsMat;

                                }//dropdown.value != tempLegsMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Legs
                
                
////////////////
///
///     LEGS UPPER
///
////////////////


                    if(characterType.player.mainBody[mb].name == "Legs Upper"){
                    
                        if(characterType.player.mainBody[mb].materials.Length > 0){

                            if(characterType.player.mainBody[mb].materials.Length > 1){

                                tempLegsUpperMat = Random.Range(0, characterType.player.mainBody[mb].materials.Length);

                                if(characterType.player.mainBody[mb].dropdown.value != tempLegsUpperMat){

                                    characterType.player.mainBody[mb].dropdown.value = tempLegsUpperMat;

                                }//dropdown.value != tempLegsUpperMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.player.mainBody[mb].dropdown.value != 0){

                                    characterType.player.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Legs Upper

                }//for mb mainBody

            }//mainBody.Length > 0            
            
        }//charTypeCurrent = player
        
        
/////////////////////////////
///
///     ENEMY
///
/////////////////////////////

        
        if(charTypeCurrent == CharType_Current.Enemy){
            
            
///////////////////////
///
///     BODY PIECES
///
///////////////////////
            
////////////////
///
///     BELTS
///
////////////////
            
            
            if(characterType.enemy.belts.Length > 0){
                
                tempBeltChance = Random.Range(0, 2);
                
                if(tempBeltChance == 1){
                
                    if(characterType.enemy.belts.Length > 1){

                        tempBelt = Random.Range(0, characterType.enemy.belts.Length);
                        tempBeltMat = Random.Range(0, characterType.enemy.belts[tempBelt].materials.Length);
                        
                        characterType.enemy.referencesUI.belts.part.value = tempBelt + 1;
                        characterType.enemy.referencesUI.belts.material.value = tempBeltMat;
                        
                    //tempBeltChance = 1
                    } else {
                    
                        tempBeltMat = Random.Range(0, characterType.enemy.belts[0].materials.Length);

                        characterType.enemy.referencesUI.belts.part.value = 1;
                        characterType.enemy.referencesUI.belts.material.value = tempBeltMat;

                    }//tempBeltChance = 1
                    
                //tempBeltChance = active
                } else {
                
                    characterType.enemy.referencesUI.belts.part.value = 0;
                
                }//tempBeltChance = active
                
            }//enemy.belts.Length > 0

            
////////////////
///
///     BROWS
///
////////////////
            

            if(characterType.enemy.brows.Length > 0){

                if(characterType.enemy.brows.Length > 1){

                    tempBrow = Random.Range(0, characterType.enemy.brows.Length);
                    tempBrowMat = Random.Range(0, characterType.enemy.brows[tempBrow].materials.Length);
                    
                    characterType.enemy.referencesUI.brows.part.value = tempBrow + 1;
                    characterType.enemy.referencesUI.brows.material.value = tempBrowMat;

                //enemy.brows.Length > 1
                } else {

                    tempBrowMat = Random.Range(0, characterType.enemy.brows[0].materials.Length);

                    characterType.enemy.referencesUI.brows.part.value = 1;
                    characterType.enemy.referencesUI.brows.material.value = tempBrowMat;

                }//enemy.brows.Length > 1
                
            }//enemy.brows.Length > 0
            

////////////////
///
///     BUCKLES OUTER
///
////////////////
            
            
            if(characterType.enemy.bucklesOuter.Length > 0){
                
                if(tempBeltChance > 0){
                
                    tempBuckOuterChance = Random.Range(0, 2);
                
                    if(tempBuckOuterChance == 1){

                        if(characterType.enemy.bucklesOuter.Length > 1){

                            tempBuckOuter = Random.Range(0, characterType.enemy.bucklesOuter.Length);
                            tempBuckOuterMat = Random.Range(0, characterType.enemy.bucklesOuter[tempBuckOuter].materials.Length);

                            characterType.enemy.referencesUI.bucklesOuter.part.value = tempBuckOuter + 1;
                            characterType.enemy.referencesUI.bucklesOuter.material.value = tempBuckOuterMat;

                        //enemy.bucklesOuter.Length > 1
                        } else {

                            tempBuckOuterMat = Random.Range(0, characterType.enemy.bucklesOuter[0].materials.Length);

                            characterType.enemy.referencesUI.bucklesOuter.part.value = 1;
                            characterType.enemy.referencesUI.bucklesOuter.material.value = tempBuckOuterMat;

                        }//enemy.bucklesOuter.Length > 1

                    //tempBuckOuterChance = active
                    } else {
                    
                        characterType.enemy.referencesUI.bucklesOuter.part.value = 0;
                    
                    }//tempBuckOuterChance = active
                
                //tempBeltChance > 0
                } else {
                
                    characterType.enemy.referencesUI.bucklesOuter.part.value = 0;
                
                }//tempBeltChance > 0
                
            }//enemy.bucklesOuter.Length > 0
            
            
////////////////
///
///     BUCKLES INNER
///
////////////////
            
            
            if(characterType.enemy.bucklesInner.Length > 0){
                
                if(tempBeltChance > 0 && tempBuckOuterChance > 0){
                
                    tempBuckInnerChance = Random.Range(0, 2);
                
                    if(tempBuckInnerChance == 1){

                        if(characterType.enemy.bucklesInner.Length > 1){

                            tempBuckInner = Random.Range(0, characterType.enemy.bucklesInner.Length);
                            tempBuckInnerMat = Random.Range(0, characterType.enemy.bucklesInner[tempBuckInner].materials.Length);

                            characterType.enemy.referencesUI.bucklesInner.part.value = tempBuckInner + 1;
                            characterType.enemy.referencesUI.bucklesInner.material.value = tempBuckInnerMat;

                        //enemy.bucklesInner.Length > 1
                        } else {

                            tempBuckInnerMat = Random.Range(0, characterType.enemy.bucklesInner[0].materials.Length);

                            characterType.enemy.referencesUI.bucklesInner.part.value = 1;
                            characterType.enemy.referencesUI.bucklesInner.material.value = tempBuckInnerMat;

                        }//enemy.bucklesInner.Length > 1

                    //tempBuckInnerChance = active
                    } else {
                    
                        characterType.enemy.referencesUI.bucklesInner.part.value = 0;
                    
                    }//tempBuckInnerChance = active
                
                //tempBeltChance > 0 & tempBuckOuterChance > 0
                } else {
                
                    characterType.enemy.referencesUI.bucklesInner.part.value = 0;
                
                }//tempBeltChance > 0 & tempBuckOuterChance > 0
                
            }//enemy.bucklesInner.Length > 0
            
            
////////////////
///
///     COLLARS
///
////////////////
            
            
            if(characterType.enemy.collars.Length > 0){
                
                tempCollarChance = Random.Range(0, 2);
                
                if(tempCollarChance == 1){
                
                    if(characterType.enemy.collars.Length > 1){

                        tempCollar = Random.Range(0, characterType.enemy.collars.Length);
                        tempCollarMat = Random.Range(0, characterType.enemy.collars[tempCollar].materials.Length);

                        characterType.enemy.referencesUI.collars.part.value = tempCollar + 1;
                        characterType.enemy.referencesUI.collars.material.value = tempCollarMat;

                    //enemy.collars.Length > 1
                    } else {

                        tempCollarMat = Random.Range(0, characterType.enemy.collars[0].materials.Length);

                        characterType.enemy.referencesUI.collars.part.value = 1;
                        characterType.enemy.referencesUI.collars.material.value = tempCollarMat;

                    }//enemy.collars.Length > 1
                
                //tempCollarChance = active
                } else {
                    
                    characterType.enemy.referencesUI.collars.part.value = 0;
                    
                }//tempCollarChance = active
                
            }//enemy.collars.Length > 0
            
            
////////////////
///
///     CLOTHS INNER
///
////////////////
            
            
            if(characterType.enemy.clothsInner.Length > 0){
                
                tempClothInnerChance = Random.Range(0, 2);
                
                if(tempClothInnerChance == 1){
                
                    if(characterType.enemy.clothsInner.Length > 1){

                        tempClothInner = Random.Range(0, characterType.enemy.clothsInner.Length);
                        tempClothInnerMat = Random.Range(0, characterType.enemy.clothsInner[tempClothInner].materials.Length);

                        characterType.enemy.referencesUI.clothsInner.part.value = tempClothInner + 1;
                        characterType.enemy.referencesUI.clothsInner.material.value = tempClothInnerMat;

                    //enemy.clothsInner.Length > 1
                    } else {

                        tempClothInnerMat = Random.Range(0, characterType.enemy.clothsInner[0].materials.Length);

                        characterType.enemy.referencesUI.clothsInner.part.value = 1;
                        characterType.enemy.referencesUI.clothsInner.material.value = tempClothInnerMat;

                    }//enemy.clothsInner.Length > 1
                    
                //tempClothInnerChance = active
                } else {
                    
                    characterType.enemy.referencesUI.clothsInner.part.value = 0;
                    
                }//tempClothInnerChance = active
                
            }//enemy.clothsInner.Length > 0
            
            
////////////////
///
///     CLOTHS OUTER
///
/////////////////
            
            
            if(characterType.enemy.clothsOuter.Length > 0){
                
                tempClothOuterChance = Random.Range(0, 2);
                
                if(tempClothOuterChance == 1){
                
                    if(characterType.enemy.clothsOuter.Length > 1){

                        tempClothOuter = Random.Range(0, characterType.enemy.clothsOuter.Length);
                        tempClothOuterMat = Random.Range(0, characterType.enemy.clothsOuter[tempClothOuter].materials.Length);

                        characterType.enemy.referencesUI.clothsOuter.part.value = tempClothOuter + 1;
                        characterType.enemy.referencesUI.clothsOuter.material.value = tempClothOuterMat;

                    //enemy.clothsInner.Length > 1
                    } else {

                        tempClothOuterMat = Random.Range(0, characterType.enemy.clothsOuter[0].materials.Length);

                        characterType.enemy.referencesUI.clothsOuter.part.value = 1;
                        characterType.enemy.referencesUI.clothsOuter.material.value = tempClothOuterMat;

                    }//enemy.clothsOuter.Length > 1
                    
                //tempClothOuterChance = active
                } else {
                    
                    characterType.enemy.referencesUI.clothsOuter.part.value = 0;
                    
                }//tempClothOuterChance = active
                
            }//enemy.clothsOuter.Length > 0
            
            
////////////////
///
///     HORNS
///
/////////////////
            
            
            if(characterType.enemy.horns.Length > 0){
                
                tempHornsChance = Random.Range(0, 2);
                
                if(tempHornsChance == 1){
                
                    if(characterType.enemy.horns.Length > 1){

                        tempHorns = Random.Range(0, characterType.enemy.horns.Length);
                        tempHornsMat = Random.Range(0, characterType.enemy.horns[tempHorns].materials.Length);

                        characterType.enemy.referencesUI.horns.part.value = tempHorns + 1;
                        characterType.enemy.referencesUI.horns.material.value = tempHornsMat;

                    //enemy.horns.Length > 1
                    } else {

                        tempHornsMat = Random.Range(0, characterType.enemy.horns[0].materials.Length);

                        characterType.enemy.referencesUI.horns.part.value = 1;
                        characterType.enemy.referencesUI.horns.material.value = tempHornsMat;

                    }//enemy.horns.Length > 1
                    
                //tempHornsChance = active
                } else {
                    
                    characterType.enemy.referencesUI.horns.part.value = 0;
                    
                }//tempHornsChance = active
                
            }//enemy.horns.Length > 0
            
            
////////////////
///
///     SHOULDER PADS
///
////////////////
            
            
            if(characterType.enemy.shoulderPads.Length > 0){
                
                tempShouldPadsChance = Random.Range(0, 3);
                
                for(int shp = 0; shp < characterType.enemy.shoulderPads.Length; shp++) {
                    
                    characterType.enemy.shoulderPads[shp].holder.SetActive(false);
                                        
                }//for shp enemy.shoulderPads
                
                if(tempShouldPadsChance == 0){
                
                    characterType.enemy.referencesUI.shoulderPads.part.value = 0;
                
                }//tempShouldPadsChance = not active
                
                if(tempShouldPadsChance == 1){
                
                    if(characterType.enemy.shoulderPads.Length > 1){

                        tempShouldPad = Random.Range(0, characterType.enemy.shoulderPads.Length);
                        tempShouldPadMat = Random.Range(0, characterType.enemy.shoulderPads[tempShouldPad].materials.Length);

                        characterType.enemy.referencesUI.shoulderPads.part.value = tempShouldPad + 2;
                        characterType.enemy.referencesUI.shoulderPads.material.value = tempShouldPadMat;

                    //enemy.clothsInner.Length > 1
                    } else {

                        tempClothOuterMat = Random.Range(0, characterType.enemy.shoulderPads[0].materials.Length);

                        characterType.enemy.referencesUI.shoulderPads.part.value = 2;
                        characterType.enemy.referencesUI.shoulderPads.material.value = tempClothOuterMat;

                    }//enemy.shoulderPads.Length > 1
                    
                }//tempShouldPadsChance = single pad
                
                if(tempShouldPadsChance == 2){
                
                    tempShouldPadMat = Random.Range(0, characterType.enemy.shoulderPads[0].materials.Length);

                    characterType.enemy.referencesUI.shoulderPads.part.value = 1;
                    characterType.enemy.referencesUI.shoulderPads.material.value = tempShouldPadMat;
                
                }//tempShouldPadsChance = dual pads pad
                
            }//enemy.shoulderPads.Length > 0 
            
            
///////////////////////
///
///     BODY
///
///////////////////////
            

            if(characterType.enemy.mainBody.Length > 0){

                for(int mb = 0; mb < characterType.enemy.mainBody.Length; mb++) {
            
            
////////////////
///
///     HEAD
///
////////////////
            

                    if(characterType.enemy.mainBody[mb].name == "Head"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempHeadMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempHeadMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempHeadMat;

                                }//dropdown.value != tempHeadMat

                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0
                        
                    }//name = Head
                
                
////////////////
///
///     NECK
///
////////////////
                
                
                    if(characterType.enemy.mainBody[mb].name == "Neck"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempNeckMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempNeckMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempNeckMat;

                                }//dropdown.value != tempNeckMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Neck
                
                
////////////////
///
///     EYES
///
////////////////
                
                
                    if(characterType.enemy.mainBody[mb].name == "Eyes"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempEyesMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempEyesMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempEyesMat;

                                }//dropdown.value != tempEyesMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Eyes
                

////////////////
///
///     TORSO
///
////////////////
                
                
                    if(characterType.enemy.mainBody[mb].name == "Torso"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempTorsoMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempTorsoMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempTorsoMat;

                                }//dropdown.value != tempTorsoMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Torso
                
                
////////////////
///
///     PELVIS
///
////////////////
                
                
                    if(characterType.enemy.mainBody[mb].name == "Pelvis"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempPelvisMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempPelvisMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempPelvisMat;

                                }//dropdown.value != tempPelvisMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Pelvis
                
                
////////////////
///
///     HANDS
///
////////////////

                
                    if(characterType.enemy.mainBody[mb].name == "Hands"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempHandsMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempHandsMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempHandsMat;

                                }//dropdown.value != tempHandsMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Hands
                
                
////////////////
///
///     FEET
///
////////////////

                
                    if(characterType.enemy.mainBody[mb].name == "Feet"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempFeetMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempFeetMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempFeetMat;

                                }//dropdown.value != tempFeetMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Feet
                
                
////////////////
///
///     LEGS
///
////////////////

                
                    if(characterType.enemy.mainBody[mb].name == "Legs"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempLegsMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempLegsMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempLegsMat;

                                }//dropdown.value != tempLegsMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Legs
                
                
////////////////
///
///     LEGS UPPER
///
////////////////


                    if(characterType.enemy.mainBody[mb].name == "Legs Upper"){
                    
                        if(characterType.enemy.mainBody[mb].materials.Length > 0){

                            if(characterType.enemy.mainBody[mb].materials.Length > 1){

                                tempLegsUpperMat = Random.Range(0, characterType.enemy.mainBody[mb].materials.Length);

                                if(characterType.enemy.mainBody[mb].dropdown.value != tempLegsUpperMat){

                                    characterType.enemy.mainBody[mb].dropdown.value = tempLegsUpperMat;

                                }//dropdown.value != tempLegsUpperMat
                        
                            //materials.Length > 1
                            } else {

                                if(characterType.enemy.mainBody[mb].dropdown.value != 0){

                                    characterType.enemy.mainBody[mb].dropdown.value = 0;

                                }//dropdown.value != tempHeadMat

                            }//materials.Length > 1
                        
                        }//materials.Length > 0

                    }//name = Legs Upper

                }//for mb mainBody

            }//mainBody.Length > 0 
            
        }//charTypeCurrent = enemy
        
    }//Character_Randomize
    
    
//////////////////////////////
///
///     PREFAB ACTIONS
///
//////////////////////////////
    
    
    public void PrefabMenu_Show(){
    
        StartCoroutine("PrefabMenu_ShowBuff");    
        
    }//PrefabMenu_Show
    
    private IEnumerator PrefabMenu_ShowBuff(){
    
        MainUI_Hide();
        
        yield return new WaitForSeconds(0.4f);
        
        menuAnimations.prefabCharName.holder.SetActive(true);
                
        menuAnimations.prefabCharName.anim.Play(menuAnimations.prefabCharName.show);
    
    }//PrefabMenu_ShowBuff
    
    public void PrefabMenu_Hide(){
    
        StartCoroutine("PrefabMenu_HideBuff");    
        
    }//PrefabMenu_Hide
    
    private IEnumerator PrefabMenu_HideBuff(){
                
        menuAnimations.prefabCharName.anim.Play(menuAnimations.prefabCharName.hide);
    
        yield return new WaitForSeconds(0.4f);
        
        MainUI_Show();
        
        menuAnimations.prefabCharName.holder.SetActive(false);
        
        charNameInput.text = "";
    
    }//PrefabMenu_HideBuff
    
    #if UNITY_EDITOR
    
    public void Prefab_Create(){
        
        tempSavePath = "";
        
        tempSavePath = EditorUtility.OpenFolderPanel("Select A Folder", Application.dataPath, "");
        
        if(tempSavePath != ""){
        
            string relativePath = tempSavePath.Substring(tempSavePath.IndexOf("Assets/"));
            
            string localPath = relativePath + "/" + charNameInput.text + ".prefab";
            
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        
            PrefabUtility.SaveAsPrefabAsset(characterHolder, localPath, out saveSuccess);

            if(saveSuccess){

                prefabSaveHeader.text = "PREFAB SAVED!";

                //Debug.Log("Success");
                
            //saveSuccess
            } else {

                //Debug.Log("Failed");
                
                prefabSaveHeader.text = "PREFAB SAVE FAIL!";

            }//saveSuccess
            
            StartCoroutine("PrefabAnim_Buff");
            
        }//tempSavePath != ""
        
    }//Prefab_Create
    
    #endif
    
    private IEnumerator PrefabAnim_Buff(){
    
        yield return new WaitForSeconds(0.5f);
    
        menuAnimations.prefabCharName.anim.Play(menuAnimations.prefabCharName.hide);
    
        yield return new WaitForSeconds(0.5f);
    
        menuAnimations.savePrefab.holder.SetActive(true);
        menuAnimations.prefabCharName.holder.SetActive(false);
                
        menuAnimations.savePrefab.anim.Play(menuAnimations.savePrefab.show);
        
        charNameInput.text = "";
        
        yield return new WaitForSeconds(1.5f);
        
        MainUI_Show();
    
        yield return new WaitForSeconds(1);
        
        menuAnimations.savePrefab.holder.SetActive(false);
        
    }//PrefabAnim_Buff
    
    
//////////////////////////////
///
///     MAIN UI ACTIONS
///
//////////////////////////////

    
    public void MainUI_Show(){
    
        menuAnimations.charType.anim.Play(menuAnimations.charType.show);
        menuAnimations.bodyPieces.anim.Play(menuAnimations.bodyPieces.show);
        menuAnimations.mainBody.anim.Play(menuAnimations.mainBody.show);
        menuAnimations.bottom.anim.Play(menuAnimations.bottom.show);
        
    }//MainUI_Show
    
    public void MainUI_Hide(){
    
        menuAnimations.charType.anim.Play(menuAnimations.charType.hide);
        menuAnimations.bodyPieces.anim.Play(menuAnimations.bodyPieces.hide);
        menuAnimations.mainBody.anim.Play(menuAnimations.mainBody.hide);
        menuAnimations.bottom.anim.Play(menuAnimations.bottom.hide);
        
    }//MainUI_Hide
    

    
}

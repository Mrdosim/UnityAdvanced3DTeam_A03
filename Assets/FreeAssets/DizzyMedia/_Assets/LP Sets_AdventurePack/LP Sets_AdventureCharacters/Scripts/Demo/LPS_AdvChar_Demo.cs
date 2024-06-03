using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LPS_AdvChar_Demo : MonoBehaviour {
    
    
//////////////////////////////////////
///
///     CLASSES
///
///////////////////////////////////////
    
    
    [System.Serializable]
    public class Display {
        
        [Space]
        
        public GameObject charHolder;
        public GameObject weapHolder;
        
        [Space]
        
        public Dropdown charDrop;
        public Dropdown weapDrop;
        
        [Space]
        
        public ObjectType player;
        public ObjectType enemy;
        
        [Space]
        
        public ObjectType weapStaff;
        public ObjectType weapSword;
        public ObjectType weapDagger;
        public ObjectType weapShieldType1;
        public ObjectType weapShieldType2;
        
    }//Display
    
    
    [System.Serializable]
    public class ObjectType {
        
        [Space]
        
        public GameObject mainHolder;
        public Dropdown dropHolder;
        public ObjectHolders[] holders;
        
    }//ObjectType
    
    [System.Serializable]
    public class ObjectHolders {
        
        public string name;
        public GameObject holder;
        public LPS_RotateObject rotateObject;
        
    }//ObjectHolders
    
    
//////////////////////////////////////
///
///     VALUES
///
///////////////////////////////////////
    
    
    public Display display;
    
    
//////////////////////////////////////
///
///     START ACTIONS
///
///////////////////////////////////////
    

    void Start() {
        
        StartInit();
        
    }//Start

    public void StartInit(){
        
        display.charHolder.SetActive(true);
        display.weapHolder.SetActive(false);
        
        display.charDrop.gameObject.SetActive(true);
        display.weapDrop.gameObject.SetActive(false);
        
        display.player.dropHolder.gameObject.SetActive(true);
        display.enemy.dropHolder.gameObject.SetActive(false);
        
        for(int ph = 0; ph < display.player.holders.Length; ph++) {
            
            display.player.holders[ph].holder.SetActive(false);
            
        }//for ph player.holders
        
        display.player.holders[0].holder.SetActive(true);
        
        for(int eh = 0; eh < display.enemy.holders.Length; eh++) {
            
            display.enemy.holders[eh].holder.SetActive(false);
            
        }//for eh enemy.holders
        
        display.enemy.holders[0].holder.SetActive(true);
        
        
////////////////////////
///
///     STAFF
///
////////////////////////
        
        
        display.weapStaff.mainHolder.SetActive(true);
        display.weapStaff.dropHolder.gameObject.SetActive(false);
        
        for(int wpst = 0; wpst < display.weapStaff.holders.Length; wpst++) {
            
            display.weapStaff.holders[wpst].holder.SetActive(false);
            
        }//for wpst weapStaff.holders
        
        display.weapStaff.holders[0].holder.SetActive(true);
        
        
////////////////////////
///
///     SWORD
///
////////////////////////
        
        
        display.weapSword.mainHolder.SetActive(false);
        display.weapSword.dropHolder.gameObject.SetActive(false);
        
        for(int wpsw = 0; wpsw < display.weapSword.holders.Length; wpsw++) {
            
            display.weapSword.holders[wpsw].holder.SetActive(false);
            
        }//for wpsw weapSword.holders
        
        display.weapSword.holders[0].holder.SetActive(true);
        
        
////////////////////////
///
///     DAGGER
///
////////////////////////
        
        
        display.weapDagger.mainHolder.SetActive(false);
        display.weapDagger.dropHolder.gameObject.SetActive(false);
        
        for(int wpdg = 0; wpdg < display.weapDagger.holders.Length; wpdg++) {
            
            display.weapDagger.holders[wpdg].holder.SetActive(false);
            
        }//for wpdg weapDagger.holders
        
        display.weapDagger.holders[0].holder.SetActive(true);
        
        
////////////////////////
///
///     SHIELD TYPE 1
///
////////////////////////
        
        
        display.weapShieldType1.mainHolder.SetActive(false);
        display.weapShieldType1.dropHolder.gameObject.SetActive(false);
        
        for(int wpsh1 = 0; wpsh1 < display.weapShieldType1.holders.Length; wpsh1++) {
            
            display.weapShieldType1.holders[wpsh1].holder.SetActive(false);
            
        }//for wpsh1 weapShieldType1.holders
        
        display.weapShieldType1.holders[0].holder.SetActive(true);
        
        
////////////////////////
///
///     SHIELD TYPE 2
///
////////////////////////
        
        
        display.weapShieldType2.mainHolder.SetActive(false);
        display.weapShieldType2.dropHolder.gameObject.SetActive(false);
        
        for(int wpsh2 = 0; wpsh2 < display.weapShieldType2.holders.Length; wpsh2++) {
            
            display.weapShieldType2.holders[wpsh2].holder.SetActive(false);
            
        }//for wpsh2 weapShieldType2.holders
        
        display.weapShieldType2.holders[0].holder.SetActive(true);
        
    }//StartInit
    
    
    
    
//////////////////////////////////////
///
///     DROPDOWN ACTIONS
///
///////////////////////////////////////
    
//////////////////////////////
///
///     DISPLAY ACTIONS
///
//////////////////////////////
    
    
    public void DisplayType(int type){
        
        if(type == 0){
            
            display.charHolder.SetActive(true);
            display.weapHolder.SetActive(false);
            
            display.charDrop.gameObject.SetActive(true);
            display.weapDrop.gameObject.SetActive(false);
            
            display.weapStaff.dropHolder.gameObject.SetActive(false);
            display.weapSword.dropHolder.gameObject.SetActive(false);
            display.weapDagger.dropHolder.gameObject.SetActive(false);
            display.weapShieldType1.dropHolder.gameObject.SetActive(false);
            display.weapShieldType2.dropHolder.gameObject.SetActive(false);
            
            if(display.charDrop.value == 0){
                
                display.player.dropHolder.gameObject.SetActive(true);
                display.enemy.dropHolder.gameObject.SetActive(false);
                
                for(int i = 0; i < display.player.holders.Length; i++) {

                    if(display.player.holders[i].holder.activeSelf){

                        if(display.player.holders[i].rotateObject != null){

                            display.player.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i player.holders
                
            //charDrop.value = player
            } else {
                
                display.player.dropHolder.gameObject.SetActive(false);
                display.enemy.dropHolder.gameObject.SetActive(true);
                
                for(int i = 0; i < display.enemy.holders.Length; i++) {

                    if(display.enemy.holders[i].holder.activeSelf){

                        if(display.enemy.holders[i].rotateObject != null){

                            display.enemy.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i enemy.holders
                
            }//charDrop.value = player
            
        //type = character
        } else {
            
            display.charHolder.SetActive(false);
            display.weapHolder.SetActive(true);
            
            display.charDrop.gameObject.SetActive(false);
            display.weapDrop.gameObject.SetActive(true);
            
            display.player.dropHolder.gameObject.SetActive(false);
            display.enemy.dropHolder.gameObject.SetActive(false);
            
            if(display.weapDrop.value == 0){
                
                display.weapStaff.dropHolder.gameObject.SetActive(true);
                
                for(int i = 0; i < display.weapStaff.holders.Length; i++) {

                    if(display.weapStaff.holders[i].holder.activeSelf){

                        if(display.weapStaff.holders[i].rotateObject != null){

                            display.weapStaff.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i weapStaff.holders
                
            }//weapDrop.value = staff
            
            if(display.weapDrop.value == 1){
                
                display.weapSword.dropHolder.gameObject.SetActive(true);
                
                for(int i = 0; i < display.weapSword.holders.Length; i++) {

                    if(display.weapSword.holders[i].holder.activeSelf){

                        if(display.weapSword.holders[i].rotateObject != null){

                            display.weapSword.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i weapSword.holders
                
            }//weapDrop.value = sword
            
            if(display.weapDrop.value == 2){
                
                display.weapDagger.dropHolder.gameObject.SetActive(true);
                
                for(int i = 0; i < display.weapDagger.holders.Length; i++) {

                    if(display.weapDagger.holders[i].holder.activeSelf){

                        if(display.weapDagger.holders[i].rotateObject != null){

                            display.weapDagger.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i weapDagger.holders
                
            }//weapDrop.value = dagger
            
            if(display.weapDrop.value == 3){
                
                display.weapShieldType1.dropHolder.gameObject.SetActive(true);
                
                for(int i = 0; i < display.weapShieldType1.holders.Length; i++) {

                    if(display.weapShieldType1.holders[i].holder.activeSelf){

                        if(display.weapShieldType1.holders[i].rotateObject != null){

                            display.weapShieldType1.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i weapShieldType1.holders
                
            }//weapDrop.value = shield type 1
    
            if(display.weapDrop.value == 4){
                
                display.weapShieldType2.dropHolder.gameObject.SetActive(true);
                
                for(int i = 0; i < display.weapShieldType2.holders.Length; i++) {

                    if(display.weapShieldType2.holders[i].holder.activeSelf){

                        if(display.weapShieldType2.holders[i].rotateObject != null){

                            display.weapShieldType2.holders[i].rotateObject.Reset_Rotation();

                        }//rotateObject != null

                    }//activeSelf

                }//for i weapShieldType2.holders
                
            }//weapDrop.value = shield type 2
            
        }//type = character
        
    }//DisplayType
    
    
//////////////////////////////
///
///     CHARACTER ACTIONS
///
//////////////////////////////
    
    
    public void CharType(int type){
        
        if(type == 0){
           
            display.player.mainHolder.SetActive(true);            
            display.enemy.mainHolder.SetActive(false);
            
            display.player.dropHolder.gameObject.SetActive(true);
            display.enemy.dropHolder.gameObject.SetActive(false);
            
            for(int i = 0; i < display.player.holders.Length; i++) {

                if(display.player.holders[i].holder.activeSelf){

                    if(display.player.holders[i].rotateObject != null){

                        display.player.holders[i].rotateObject.Reset_Rotation();

                    }//rotateObject != null

                }//activeSelf

            }//for i player.holders
            
        }//player
        
        if(type == 1){
            
            display.player.mainHolder.SetActive(false);            
            display.enemy.mainHolder.SetActive(true);
            
            display.player.dropHolder.gameObject.SetActive(false);
            display.enemy.dropHolder.gameObject.SetActive(true);
            
            for(int i = 0; i < display.enemy.holders.Length; i++) {

                if(display.enemy.holders[i].holder.activeSelf){

                    if(display.enemy.holders[i].rotateObject != null){

                        display.enemy.holders[i].rotateObject.Reset_Rotation();

                    }//rotateObject != null

                }//activeSelf

            }//for i enemy.holders
            
        }//enemy
        
    }//CharType
    
    
//////////////////////////////
///
///     TEMPLATE ACTIONS
///
//////////////////////////////
    
////////////////////////
///
///     PLAYER
///
////////////////////////
    
    
    public void PlayerTemp(int type){
       
        for(int i = 0; i < display.player.holders.Length; i++) {
            
            display.player.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.player.holders[i].holder.SetActive(true);
                
                if(display.player.holders[i].rotateObject != null){
                
                    display.player.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i player.holders
        
    }//PlayerTemp
    
    
////////////////////////
///
///     ENEMY
///
////////////////////////
    
    
    public void EnemyTemp(int type){
       
        for(int i = 0; i < display.enemy.holders.Length; i++) {
            
            display.enemy.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.enemy.holders[i].holder.SetActive(true);
                
                if(display.enemy.holders[i].rotateObject != null){
                
                    display.enemy.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i enemy.holders
        
    }//EnemyTemp
    
    
////////////////////////
///
///     STAFF
///
////////////////////////
    
    
    public void StaffTemp(int type){
       
        for(int i = 0; i < display.weapStaff.holders.Length; i++) {
            
            display.weapStaff.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.weapStaff.holders[i].holder.SetActive(true);
                
                if(display.weapStaff.holders[i].rotateObject != null){
                
                    display.weapStaff.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i weapStaff.holders
        
    }//StaffTemp
    
    
////////////////////////
///
///     SWORD
///
////////////////////////
    
    
    public void SwordTemp(int type){
       
        for(int i = 0; i < display.weapSword.holders.Length; i++) {
            
            display.weapSword.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.weapSword.holders[i].holder.SetActive(true);
                
                if(display.weapSword.holders[i].rotateObject != null){
                
                    display.weapSword.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i weapSword.holders
        
    }//SwordTemp
    

////////////////////////
///
///     DAGGER
///
////////////////////////
    
    
    public void DaggerTemp(int type){
       
        for(int i = 0; i < display.weapDagger.holders.Length; i++) {
            
            display.weapDagger.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.weapDagger.holders[i].holder.SetActive(true);
                
                if(display.weapDagger.holders[i].rotateObject != null){
                
                    display.weapDagger.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i weapDagger.holders
        
    }//DaggerTemp
    
    
////////////////////////
///
///     SHIELD TYPE 1
///
////////////////////////
    
    
    public void ShieldType1_Temp(int type){
       
        for(int i = 0; i < display.weapShieldType1.holders.Length; i++) {
            
            display.weapShieldType1.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.weapShieldType1.holders[i].holder.SetActive(true);
                
                if(display.weapShieldType1.holders[i].rotateObject != null){
                
                    display.weapShieldType1.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i weapShieldType1.holders
        
    }//ShieldType1_Temp
    

////////////////////////
///
///     SHIELD TYPE 2
///
////////////////////////
    
    
    public void ShieldType2_Temp(int type){
       
        for(int i = 0; i < display.weapShieldType2.holders.Length; i++) {
            
            display.weapShieldType2.holders[i].holder.SetActive(false);
            
            if(i == type){
                
                display.weapShieldType2.holders[i].holder.SetActive(true);
                
                if(display.weapShieldType2.holders[i].rotateObject != null){
                
                    display.weapShieldType2.holders[i].rotateObject.Reset_Rotation();
                
                }//rotateObject != null
                
            }//i == type
            
        }//for i weapShieldType2.holders
        
    }//ShieldType1_Temp
    
    
//////////////////////////////
///
///     WEAPON ACTIONS
///
//////////////////////////////
    
    
    public void WeapType(int type){
        
        
////////////////////////
///
///     STAFF
///
////////////////////////
        
        
        display.weapStaff.mainHolder.SetActive(false);
        display.weapStaff.dropHolder.gameObject.SetActive(false);
        
        
////////////////////////
///
///     SWORD
///
////////////////////////
        
        
        display.weapSword.mainHolder.SetActive(false);
        display.weapSword.dropHolder.gameObject.SetActive(false);
        
        
////////////////////////
///
///     DAGGER
///
////////////////////////
        
        
        display.weapDagger.mainHolder.SetActive(false);
        display.weapDagger.dropHolder.gameObject.SetActive(false);
        
        
////////////////////////
///
///     SHIELD TYPE 1
///
////////////////////////
        
        
        display.weapShieldType1.mainHolder.SetActive(false);
        display.weapShieldType1.dropHolder.gameObject.SetActive(false);
        
        
////////////////////////
///
///     SHIELD TYPE 2
///
////////////////////////
        
        
        display.weapShieldType2.mainHolder.SetActive(false);
        display.weapShieldType2.dropHolder.gameObject.SetActive(false);
        
        
////////////////////////
///
///     TYPE CHECK
///
////////////////////////
        
        
        if(type == 0){
            
            display.weapStaff.mainHolder.SetActive(true);
            display.weapStaff.dropHolder.gameObject.SetActive(true);
            
        }//type = staff
        
        if(type == 1){
            
            display.weapSword.mainHolder.SetActive(true);
            display.weapSword.dropHolder.gameObject.SetActive(true);
            
        }//type = sword
        
        if(type == 2){
            
            display.weapDagger.mainHolder.SetActive(true);
            display.weapDagger.dropHolder.gameObject.SetActive(true);
            
        }//type = dagger
        
        if(type == 3){
            
            display.weapShieldType1.mainHolder.SetActive(true);
            display.weapShieldType1.dropHolder.gameObject.SetActive(true);
            
        }//type = shield type 1
        
        if(type == 4){
            
            display.weapShieldType2.mainHolder.SetActive(true);
            display.weapShieldType2.dropHolder.gameObject.SetActive(true);
            
        }//type = shield type 2
        
    }//WeapType
    

}

// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paper_Talisman_Supply : Obj_Item_Weapon_Paper_Talisman {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cultist_name = "Supply Talisman";
			this.cultist_desc = "A multi-use talisman that can create various objects. Intended to increase the cult's strength early on.";
			this.invocation = null;
			this.uses = 3;
		}

		public Obj_Item_Weapon_Paper_Talisman_Supply ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: talisman.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Obj_Item_Weapon_Paper_Talisman_Teleport T = null;
			Obj_Item_Weapon_Paper_Talisman_Emp T2 = null;
			Obj_Item_Weapon_Paper_Talisman_HideRunes T3 = null;
			Obj_Item_Weapon_Paper_Talisman_Flame T4 = null;
			Obj_Item_Device_Soulstone T5 = null;
			Mob C = null;

			
			if ( !( this != null ) || Task13.User.stat != 0 || Task13.User.restrained() || !( Map13.GetDistance( this, Task13.User ) <= 1 ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["rune"] ) ) {
				
				dynamic _a = href_list["rune"]; // Was a switch-case, sorry for the mess.
				if ( _a=="teleport" ) {
					T = new Obj_Item_Weapon_Paper_Talisman_Teleport( Task13.User );
					T.keyword = "veri";
					Task13.User.put_in_hands( T );
				} else if ( _a=="emp" ) {
					T2 = new Obj_Item_Weapon_Paper_Talisman_Emp( Task13.User );
					Task13.User.put_in_hands( T2 );
				} else if ( _a=="conceal" ) {
					T3 = new Obj_Item_Weapon_Paper_Talisman_HideRunes( Task13.User );
					Task13.User.put_in_hands( T3 );
				} else if ( _a=="flame" ) {
					T4 = new Obj_Item_Weapon_Paper_Talisman_Flame( Task13.User );
					Task13.User.put_in_hands( T4 );
				} else if ( _a=="sacrune" ) {
					new Obj_Effect_Rune_Sacrifice( GlobalFuncs.get_turf( Task13.User ) );
				} else if ( _a=="soulstone" ) {
					T5 = new Obj_Item_Device_Soulstone( Task13.User );
					Task13.User.put_in_hands( T5 );
				} else if ( _a=="construct" ) {
					new Obj_Structure_Constructshell( GlobalFuncs.get_turf( Task13.User ) );
				}
				this.uses--;

				if ( this.uses <= 0 ) {
					
					if ( Task13.User is Mob_Living_Carbon ) {
						C = Task13.User;
						C.drop_item();
						this.visible_message( "<span class='warning'>" + this + " crumbles to dust.</span>" );
					}
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

		// Function from file: talisman.dm
		public override bool invoke( dynamic user = null ) {
			string dat = null;
			Browser popup = null;

			dat = "<B>There are " + this.uses + " bloody runes on the parchment.</B><BR>";
			dat += "Please choose the chant to be imbued into the fabric of reality.<BR>";
			dat += "<HR>";
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=teleport'>Sas'so c'arta forbici!</A> - Allows you to move to a Rite of Dislocation with the keyword of \"veri\".<BR>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=emp'>Ta'gh fara'qha fel d'amar det!</A> - Allows you to destroy technology in a short range.<BR>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=conceal'>Kla'atu barada nikt'o!</A> - Allows you to conceal nearby runes, or reveal previously concealed runes.<BR>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=flame'>Dedo va'batoh!</A> - Allows you to set nearby non-believers on fire.<BR>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=sacrune'>Barhah hra zar'garis!</A> - A sacrifice rune appears under your feet, ready to be invoked in the name of Nar-sie.<BR>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=soulstone'>Kal'om neth!</A> - Summons a soul stone, used to capure the spirits of dead or dying humans.<BR>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";rune=construct'>Daa'ig osk!</A> - Summons a construct shell for use with captured souls. It is too large to carry on your person.<BR>" ).ToString();
			popup = new Browser( user, "talisman", "", 400, 400 );
			popup.set_content( dat );
			popup.open();
			this.uses++;
			return true;
		}

	}

}
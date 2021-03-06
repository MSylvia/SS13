// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Coin : Obj_Item_Weapon {

		public bool? string_attached = null;
		public ByTable sideslist = new ByTable(new object [] { "heads", "tails" });
		public string cmineral = null;
		public int cooldown = 0;
		public int value = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 64;
			this.force = 1;
			this.throwforce = 2;
			this.w_class = 1;
			this.icon = "icons/obj/economy.dmi";
			this.icon_state = "coin__heads";
		}

		// Function from file: ores_coins.dm
		public Obj_Item_Weapon_Coin ( dynamic loc = null ) : base( (object)(loc) ) {
			this.pixel_x = Rand13.Int( 0, 16 ) - 8;
			this.pixel_y = Rand13.Int( 0, 8 ) - 8;
			this.icon_state = "coin_" + this.cmineral + "_heads";

			if ( Lang13.Bool( this.cmineral ) ) {
				this.name = "" + this.cmineral + " coin";
			}
			return;
		}

		// Function from file: ores_coins.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic coinflip = null;
			Ent_Static oldloc = null;

			
			if ( this.cooldown < Game13.time - 15 ) {
				
				if ( this.string_attached == true ) {
					user.WriteMsg( "<span class='warning'>The coin won't flip very well with something attached!</span>" );
					return null;
				}
				coinflip = Rand13.PickFromTable( this.sideslist );
				this.cooldown = Game13.time;
				Icon13.Flick( "coin_" + this.cmineral + "_flip", this );
				this.icon_state = "coin_" + this.cmineral + "_" + coinflip;
				GlobalFuncs.playsound( user.loc, "sound/items/coinflip.ogg", 50, 1 );
				oldloc = this.loc;
				Task13.Sleep( 15 );

				if ( this.loc == oldloc && Lang13.Bool( user ) && !((Mob)user).incapacitated() ) {
					((Ent_Static)user).visible_message( "" + user + " has flipped " + this + ". It lands on " + coinflip + ".", "<span class='notice'>You flip " + this + ". It lands on " + coinflip + ".</span>", "<span class='italics'>You hear the clattering of loose change.</span>" );
				}
			}
			return null;
		}

		// Function from file: ores_coins.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic CC = null;
			Obj_Item_Stack_CableCoil CC2 = null;

			
			if ( A is Obj_Item_Stack_CableCoil ) {
				CC = A;

				if ( this.string_attached == true ) {
					user.WriteMsg( "<span class='warning'>There already is a string attached to this coin!</span>" );
					return null;
				}

				if ( ((Obj_Item_Stack)CC).use( 1 ) != 0 ) {
					this.overlays.Add( new Image( "icons/obj/economy.dmi", "coin_string_overlay" ) );
					this.string_attached = true;
					user.WriteMsg( "<span class='notice'>You attach a string to the coin.</span>" );
				} else {
					user.WriteMsg( "<span class='warning'>You need one length of cable to attach a string to the coin!</span>" );
					return null;
				}
			} else if ( A is Obj_Item_Weapon_Wirecutters ) {
				
				if ( !( this.string_attached == true ) ) {
					base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
					return null;
				}
				CC2 = new Obj_Item_Stack_CableCoil( user.loc );
				CC2.amount = 1;
				CC2.update_icon();
				this.overlays = new ByTable();
				this.string_attached = null;
				user.WriteMsg( "<span class='notice'>You detach the string from the coin.</span>" );
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

	}

}
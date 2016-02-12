// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Armor_Reactive : Obj_Item_Clothing_Suit_Armor {

		public bool active = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "reactiveoff";
			this.blood_overlay_type = "armor";
			this.slowdown = 1;
			this.flags = 8448;
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.icon_state = "reactiveoff";
		}

		public Obj_Item_Clothing_Suit_Armor_Reactive ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: armor.dm
		public override dynamic emp_act( int severity = 0 ) {
			this.active = false;
			this.icon_state = "reactiveoff";
			this.item_state = "reactiveoff";
			base.emp_act( severity );
			return null;
		}

		// Function from file: armor.dm
		public override bool on_block( dynamic damage = null, string attack_text = null ) {
			Ent_Static L = null;
			ByTable turfs = null;
			dynamic T = null;
			dynamic picked = null;

			
			if ( !Rand13.PercentChance( 35 ) ) {
				return false;
			}
			L = this.loc;

			if ( !( L is Mob_Living_Carbon_Human ) ) {
				return false;
			}

			if ( ((dynamic)L).wear_suit != this ) {
				return false;
			}
			turfs = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this.loc, 6 ) )) {
				T = _a;
				

				if ( T is Tile_Space ) {
					continue;
				}

				if ( T.density ) {
					continue;
				}

				if ( Convert.ToDouble( T.x ) > Game13.map_size_x - 6 || Convert.ToDouble( T.x ) < 6 ) {
					continue;
				}

				if ( Convert.ToDouble( T.y ) > Game13.map_size_y - 6 || Convert.ToDouble( T.y ) < 6 ) {
					continue;
				}
				turfs.Add( T );
			}

			if ( !( turfs.len != 0 ) ) {
				turfs.Add( Rand13.PickFromTable( Map13.FetchInRangeExcludeThis( null, 6 ).Contains( typeof(Tile) ) ) );
			}
			picked = Rand13.PickFromTable( turfs );

			if ( !( picked is Tile ) ) {
				return false;
			}
			L.visible_message( "<span class='danger'>The reactive teleport system flings " + L + " clear of " + attack_text + "!</span>", "<span class='notice'>The reactive teleport system flings you clear of " + attack_text + ".</span>" );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( L ), "sound/effects/teleport.ogg", 30, 1 );
			((dynamic)L).forceMove( picked );
			return true;
		}

		// Function from file: armor.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.active = !this.active;

			if ( this.active ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>The reactive armor is now active.</span>" );
				this.icon_state = "reactive";
				this.item_state = "reactive";
			} else {
				GlobalFuncs.to_chat( user, "<span class='notice'>The reactive armor is now inactive.</span>" );
				this.icon_state = "reactiveoff";
				this.item_state = "reactiveoff";
				this.add_fingerprint( user );
			}
			return null;
		}

		// Function from file: armor.dm
		public override bool IsShield(  ) {
			
			if ( this.active ) {
				return true;
			}
			return false;
		}

	}

}
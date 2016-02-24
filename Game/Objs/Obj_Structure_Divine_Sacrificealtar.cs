// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Sacrificealtar : Obj_Structure_Divine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.metal_cost = 25;
			this.can_buckle = 1;
			this.icon_state = "sacrificealtar";
		}

		public Obj_Structure_Divine_Sacrificealtar ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: structures.dm
		public void sacrifice( dynamic L = null ) {
			int luck = 0;
			dynamic H = null;

			
			if ( !Lang13.Bool( L ) ) {
				L = Lang13.FindIn( typeof(Mob_Living), GlobalFuncs.get_turf( this ) );
			}

			if ( Lang13.Bool( L ) ) {
				
				if ( L is Mob_Living_Carbon_Monkey ) {
					luck = Rand13.Int( 1, 4 );

					if ( luck > 3 ) {
						new Obj_Item_Stack_Sheet_Lessergem( GlobalFuncs.get_turf( this ) );
					}
				} else if ( L is Mob_Living_Carbon_Human ) {
					H = L;

					if ( this.side == "red" && GlobalFuncs.is_handofgod_redcultist( H ) ) {
						return;
					} else if ( this.side == "blue" && GlobalFuncs.is_handofgod_bluecultist( H ) ) {
						return;
					}

					if ( GlobalFuncs.is_handofgod_prophet( H ) ) {
						new Obj_Item_Stack_Sheet_Greatergem( GlobalFuncs.get_turf( this ) );

						if ( this.deity != null ) {
							this.deity.prophets_sacrificed_in_name++;
						}
					} else {
						new Obj_Item_Stack_Sheet_Lessergem( GlobalFuncs.get_turf( this ) );
					}
				} else if ( L is Mob_Living_Silicon_Ai || L is Mob_Living_Carbon_Alien_Humanoid_Royal_Queen ) {
					new Obj_Item_Stack_Sheet_Greatergem( GlobalFuncs.get_turf( this ) );
				} else {
					new Obj_Item_Stack_Sheet_Lessergem( GlobalFuncs.get_turf( this ) );
				}
				((Mob)L).gib();
			}
			return;
		}

		// Function from file: structures.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic L = null;

			base.attack_hand( (object)(a), b, c );
			L = Lang13.FindIn( typeof(Mob_Living), GlobalFuncs.get_turf( this ) );

			if ( !GlobalFuncs.is_handofgod_cultist( a ) ) {
				a.WriteMsg( "<span class='notice'>You try to use it, but unfortunately you don't know any rituals.</span>" );
				return null;
			}

			if ( !Lang13.Bool( L ) ) {
				return null;
			}

			if ( this.side == "red" && GlobalFuncs.is_handofgod_redcultist( a ) || this.side == "blue" && GlobalFuncs.is_handofgod_bluecultist( a ) ) {
				
				if ( this.side == "red" && GlobalFuncs.is_handofgod_redcultist( L ) || this.side == "blue" && GlobalFuncs.is_handofgod_bluecultist( L ) ) {
					a.WriteMsg( "<span class='danger'>You cannot sacrifice a fellow cultist.</span>" );
					return null;
				}
				a.WriteMsg( "<span class='notice'>You attempt to sacrifice " + L + " by invoking the sacrificial ritual.</span>" );
				this.sacrifice( L );
			} else {
				a.WriteMsg( "<span class='notice'>You attempt to sacrifice " + L + " by invoking the sacrificial ritual.</span>" );
				a.WriteMsg( "<span class='danger'>But the altar ignores your words...</span>" );
			}
			return null;
		}

	}

}
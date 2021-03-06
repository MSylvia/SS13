// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Cultgirder : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/cult.dmi";
			this.icon_state = "cultgirder";
		}

		public Obj_Structure_Cultgirder ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: girders.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 30 ) ) {
						new Obj_Effect_Decal_Remains_Human( this.loc );
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						new Obj_Effect_Decal_Remains_Human( this.loc );
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: girders.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 40 ) ) {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: girders.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic WT = null;
			Obj_Effect_Decal_Remains_Human R = null;
			Obj_Effect_Decal_Remains_Human R2 = null;
			dynamic D = null;
			Obj_Effect_Decal_Remains_Human R3 = null;

			this.add_fingerprint( user );

			if ( A is Obj_Item_Weapon_Weldingtool ) {
				WT = A;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 50, 1 );
					user.WriteMsg( "<span class='notice'>You start slicing apart the girder...</span>" );

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						
						if ( !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
							return null;
						}
						user.WriteMsg( "<span class='notice'>You slice apart the girder.</span>" );
						R = new Obj_Effect_Decal_Remains_Human( GlobalFuncs.get_turf( this ) );
						this.transfer_fingerprints_to( R );
						GlobalFuncs.qdel( this );
					}
				}
			} else if ( A is Obj_Item_Weapon_Gun_Energy_Plasmacutter ) {
				user.WriteMsg( "<span class='notice'>You start slicing apart the girder...</span>" );
				GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

				if ( GlobalFuncs.do_after( user, 30, null, this ) ) {
					user.WriteMsg( "<span class='notice'>You slice apart the girder.</span>" );
					R2 = new Obj_Effect_Decal_Remains_Human( GlobalFuncs.get_turf( this ) );
					this.transfer_fingerprints_to( R2 );
					GlobalFuncs.qdel( this );
				}
			} else if ( A is Obj_Item_Weapon_Pickaxe_Drill_Jackhammer ) {
				D = A;
				user.WriteMsg( "<span class='notice'>Your jackhammer smashes through the girder!</span>" );
				R3 = new Obj_Effect_Decal_Remains_Human( GlobalFuncs.get_turf( this ) );
				this.transfer_fingerprints_to( R3 );
				((Obj_Item_Weapon_Pickaxe)D).playDigSound();
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}
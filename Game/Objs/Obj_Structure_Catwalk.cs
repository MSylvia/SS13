// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Catwalk : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.canSmoothWith = "/obj/structure/catwalk=0";
			this.icon = "icons/turf/catwalks.dmi";
			this.icon_state = "catwalk0";
			this.layer = 2.3;
		}

		// Function from file: catwalk.dm
		public Obj_Structure_Catwalk ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.relativewall();
			this.relativewall_neighbours();
			return;
		}

		// Function from file: catwalk.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic coil = null;

			
			if ( !Lang13.Bool( a ) || !Lang13.Bool( b ) ) {
				return 0;
			}

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				GlobalFuncs.to_chat( b, "<span class='notice'>You begin undoing the screws holding the catwalk together.</span>" );
				GlobalFuncs.playsound( this, "sound/items/Screwdriver.ogg", 80, 1 );

				if ( GlobalFuncs.do_after( b, this, 30 ) && this != null ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You finish taking taking the catwalk apart.</span>" );
					new Obj_Item_Stack_Rods( this.loc, 2 );
					new Obj_Structure_Lattice( this.loc );
					GlobalFuncs.qdel( this );
				}
				return null;
			}

			if ( a is Obj_Item_Stack_CableCoil ) {
				coil = a;

				if ( GlobalFuncs.get_turf( this ) == this.loc ) {
					((Obj_Item_Stack_CableCoil)coil).turf_place( this.loc, b );
				}
			}
			return null;
		}

		// Function from file: catwalk.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 75 ) ) {
						GlobalFuncs.qdel( this );
					} else {
						new Obj_Structure_Lattice( this.loc );
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 10 ) ) {
						new Obj_Structure_Lattice( this.loc );
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: catwalk.dm
		public override bool isSmoothableNeighbor( Ent_Static A = null ) {
			
			if ( A is Tile_Space ) {
				return false;
			}
			return base.isSmoothableNeighbor( A );
		}

		// Function from file: catwalk.dm
		public override void relativewall(  ) {
			int junction = 0;

			junction = this.findSmoothingNeighbors();
			this.icon_state = "catwalk" + junction;
			return;
		}

	}

}
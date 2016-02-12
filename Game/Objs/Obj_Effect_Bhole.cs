// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Bhole : Obj_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.unacidable = true;
			this.anchored = 1;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "bhole3";
		}

		// Function from file: black_hole.dm
		public Obj_Effect_Bhole ( dynamic loc = null ) : base( (object)(loc) ) {
			Task13.Schedule( 4, (Task13.Closure)(() => {
				this.controller();
				return;
			}));
			return;
		}

		// Function from file: black_hole.dm
		public void affect_coord( int x = 0, int y = 0, double? ex_act_force = null, int pull_chance = 0, int turf_removal_chance = 0 ) {
			Tile T = null;
			Obj O = null;
			Mob_Living M = null;
			Tile ST = null;

			T = Map13.GetTile( x, y, this.z );

			if ( T == null ) {
				return;
			}

			if ( Rand13.PercentChance( pull_chance ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( T.contents, typeof(Obj) )) {
					O = _a;
					

					if ( Lang13.Bool( O.anchored ) ) {
						O.ex_act( ex_act_force );
					} else {
						Map13.StepTowardsSimple( O, this );
					}
				}

				foreach (dynamic _b in Lang13.Enumerate( T.contents, typeof(Mob_Living) )) {
					M = _b;
					
					Map13.StepTowardsSimple( M, this );
				}
			}

			if ( T != null && T is Tile_Simulated && Rand13.PercentChance( turf_removal_chance ) ) {
				ST = T;
				ST.ChangeTurf( GlobalFuncs.get_base_turf( ST.z ) );
			}
			return;
		}

		// Function from file: black_hole.dm
		public void grav( int? r = null, double? ex_act_force = null, int pull_chance = 0, int turf_removal_chance = 0 ) {
			int? t = null;

			
			if ( !( this.loc is Tile ) ) {
				GlobalFuncs.qdel( this );
				return;
			}
			t = null;
			t = -( r ??0);

			while (( t ??0) < ( r ??0)) {
				this.affect_coord( this.x + ( t ??0), this.y - ( r ??0), ex_act_force, pull_chance, turf_removal_chance );
				this.affect_coord( this.x - ( t ??0), this.y + ( r ??0), ex_act_force, pull_chance, turf_removal_chance );
				this.affect_coord( this.x + ( r ??0), this.y + ( t ??0), ex_act_force, pull_chance, turf_removal_chance );
				this.affect_coord( this.x - ( r ??0), this.y - ( t ??0), ex_act_force, pull_chance, turf_removal_chance );
				t++;
			}
			return;
		}

		// Function from file: black_hole.dm
		public void controller(  ) {
			Mob_Living M = null;
			Obj O = null;
			Tile_Simulated ST = null;

			
			while (this != null) {
				
				if ( !( this.loc is Tile ) ) {
					GlobalFuncs.qdel( this );
					return;
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 1 ), typeof(Mob_Living) )) {
					M = _a;
					
					GlobalFuncs.qdel( M );
					M = null;
				}

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 1 ), typeof(Obj) )) {
					O = _b;
					
					GlobalFuncs.qdel( O );
					O = null;
				}

				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 1 ), typeof(Tile_Simulated) )) {
					ST = _c;
					
					ST.ChangeTurf( GlobalFuncs.get_base_turf( ST.z ) );
				}
				Task13.Sleep( 6 );
				this.grav( 10, 4, 10, 0 );
				Task13.Sleep( 6 );
				this.grav( 8, 4, 10, 0 );
				Task13.Sleep( 6 );
				this.grav( 9, 4, 10, 0 );
				Task13.Sleep( 6 );
				this.grav( 7, 3, 40, 1 );
				Task13.Sleep( 6 );
				this.grav( 5, 3, 40, 1 );
				Task13.Sleep( 6 );
				this.grav( 6, 3, 40, 1 );
				Task13.Sleep( 6 );
				this.grav( 4, 2, 50, 6 );
				Task13.Sleep( 6 );
				this.grav( 3, 2, 50, 6 );
				Task13.Sleep( 6 );
				this.grav( 2, 2, 75, 25 );
				Task13.Sleep( 6 );

				if ( Rand13.PercentChance( 50 ) ) {
					this.anchored = 0;
					Map13.Step( this, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.alldirs ) ) );
					this.anchored = 1;
				}
			}
			return;
		}

	}

}
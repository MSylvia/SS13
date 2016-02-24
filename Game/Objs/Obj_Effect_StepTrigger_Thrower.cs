// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_StepTrigger_Thrower : Obj_Effect_StepTrigger {

		public int direction = 2;
		public int tiles = 3;
		public bool immobilize = true;
		public int speed = 1;
		public bool facedir = false;
		public bool nostop = false;
		public ByTable affecting = new ByTable();

		public Obj_Effect_StepTrigger_Thrower ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: step_triggers.dm
		public override bool Trigger( Ent_Dynamic A = null ) {
			Ent_Dynamic AM = null;
			int curtiles = 0;
			bool stopthrow = false;
			Obj_Effect_StepTrigger_Thrower T = null;
			Ent_Dynamic M = null;
			Obj_Effect_StepTrigger T2 = null;
			Obj_Effect_StepTrigger_Teleporter T3 = null;
			int predir = 0;
			Ent_Dynamic M2 = null;

			
			if ( !( A != null ) || !( A is Ent_Dynamic ) ) {
				return false;
			}
			AM = A;
			curtiles = 0;
			stopthrow = false;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 2 ), typeof(Obj_Effect_StepTrigger_Thrower) )) {
				T = _a;
				

				if ( T.affecting.Contains( AM ) ) {
					return false;
				}
			}

			if ( AM is Mob ) {
				M = AM;

				if ( this.immobilize ) {
					((dynamic)M).canmove = 0;
				}
			}
			this.affecting.Add( AM );

			while (AM != null && !stopthrow) {
				
				if ( this.tiles != 0 ) {
					
					if ( curtiles >= this.tiles ) {
						break;
					}
				}

				if ( AM.z != this.z ) {
					break;
				}
				curtiles++;
				Task13.Sleep( this.speed );

				if ( !this.nostop ) {
					
					foreach (dynamic _b in Lang13.Enumerate( Map13.GetStep( AM, this.direction ), typeof(Obj_Effect_StepTrigger) )) {
						T2 = _b;
						

						if ( T2.stopper && T2 != this ) {
							stopthrow = true;
						}
					}
				} else {
					
					foreach (dynamic _c in Lang13.Enumerate( Map13.GetStep( AM, this.direction ), typeof(Obj_Effect_StepTrigger_Teleporter) )) {
						T3 = _c;
						

						if ( T3.stopper ) {
							stopthrow = true;
						}
					}
				}

				if ( AM != null ) {
					predir = AM.dir;
					Map13.Step( AM, this.direction );

					if ( !this.facedir ) {
						AM.dir = predir;
					}
				}
			}
			this.affecting.Remove( AM );

			if ( AM is Mob ) {
				M2 = AM;

				if ( this.immobilize ) {
					((dynamic)M2).canmove = 1;
				}
			}
			return false;
		}

	}

}
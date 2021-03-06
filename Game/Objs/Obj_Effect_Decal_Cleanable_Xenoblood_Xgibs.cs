// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Xenoblood_Xgibs : Obj_Effect_Decal_Cleanable_Xenoblood {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = new ByTable(new object [] { "xgib1", "xgib2", "xgib3", "xgib4", "xgib5", "xgib6" });
			this.icon_state = "xgib1";
		}

		public Obj_Effect_Decal_Cleanable_Xenoblood_Xgibs ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: aliens.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

		// Function from file: aliens.dm
		public void streak( dynamic directions = null ) {
			dynamic direction = null;
			int? i = null;
			Obj_Effect_Decal_Cleanable_Xenoblood_Xsplatter b = null;
			Disease D = null;
			dynamic ND = null;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				direction = Rand13.PickFromTable( directions );
				i = null;
				i = 0;

				while (( i ??0) < Convert.ToDouble( Rand13.PickWeighted(new object [] { 13107, 1, 39321, 2, 58981, 3, 65535, 4 }) )) {
					Task13.Sleep( 3 );

					if ( ( i ??0) > 0 ) {
						b = new Obj_Effect_Decal_Cleanable_Xenoblood_Xsplatter( this.loc );

						foreach (dynamic _a in Lang13.Enumerate( this.viruses, typeof(Disease) )) {
							D = _a;
							
							ND = D.Copy( true );
							b.viruses.Add( ND );
							ND.holder = b;
						}
					}
					Map13.StepTowards( this, Map13.GetStep( this, Convert.ToInt32( direction ) ), 0 );

					if ( ( i ??0) > 0 ) {
						break;
					}
					i++;
				}
				return;
			}));
			return;
		}

	}

}
// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon : Obj_Item_MechaParts_MechaEquipment {

		public Type projectile = null;
		public string fire_sound = null;
		public int projectiles_per_shot = 1;
		public double? deviation = 0;
		public int shot_delay = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.range = 2;
			this.origin_tech = "materials=3;combat=3";
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapons.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile | InputType.Zone )]
		public override bool f_action( dynamic target = null ) {
			dynamic curloc = null;
			dynamic targloc = null;
			double i = 0;
			dynamic A = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}
			curloc = GlobalFuncs.get_turf( this.chassis );
			targloc = GlobalFuncs.get_turf( target );

			if ( !Lang13.Bool( targloc ) || !( targloc is Tile ) || !Lang13.Bool( curloc ) ) {
				return false;
			}

			if ( targloc == curloc ) {
				return false;
			}
			this.set_ready_state( false );

			foreach (dynamic _a in Lang13.IterateRange( 1, this.get_shot_amount() )) {
				i = _a;
				
				A = Lang13.Call( this.projectile, curloc );
				A.firer = this.chassis.occupant;
				A.original = target;
				A.current = curloc;

				if ( Lang13.Bool( this.deviation ) ) {
					A.yo = Convert.ToDouble( targloc.y + Num13.Round( GlobalFuncs.gaussian( false, this.deviation ), 1 ) - curloc.y );
					A.xo = Convert.ToDouble( targloc.x + Num13.Round( GlobalFuncs.gaussian( false, this.deviation ), 1 ) - curloc.x );
				} else {
					A.yo = Convert.ToDouble( targloc.y - curloc.y );
					A.xo = Convert.ToDouble( targloc.x - curloc.x );
				}
				A.fire();
				GlobalFuncs.playsound( this.chassis, this.fire_sound, 50, 1 );

				if ( this.shot_delay != 0 ) {
					Task13.Sleep( this.shot_delay );
				}
			}
			this.chassis.log_message( "Fired from " + this.name + ", targeting " + target + "." );
			return true;
		}

		// Function from file: weapons.dm
		public virtual int get_shot_amount(  ) {
			return 1;
		}

		// Function from file: weapons.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) ) {
				
				if ( M is Obj_Mecha_Combat ) {
					return true;
				}
			}
			return false;
		}

	}

}
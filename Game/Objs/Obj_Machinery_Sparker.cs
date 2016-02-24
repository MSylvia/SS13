// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Sparker : Obj_Machinery {

		public string id = null;
		public bool disable = false;
		public int last_spark = 0;
		public string base_state = "migniter";
		public EffectSystem_SparkSpread spark_system = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon_state = "migniter";
		}

		// Function from file: igniter.dm
		public Obj_Machinery_Sparker ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.spark_system = new EffectSystem_SparkSpread();
			this.spark_system.set_up( 2, 1, this );
			this.spark_system.attach( this );
			return;
		}

		// Function from file: igniter.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return 0;
			}
			this.ignite();
			base.emp_act( severity );
			return 0;
		}

		// Function from file: igniter.dm
		public bool ignite(  ) {
			Ent_Static location = null;

			
			if ( !Lang13.Bool( this.powered() ) ) {
				return false;
			}

			if ( this.disable || this.last_spark != 0 && Game13.time < this.last_spark + 50 ) {
				return false;
			}
			Icon13.Flick( "" + this.base_state + "-spark", this );
			this.spark_system.start();
			this.last_spark = Game13.time;
			this.f_use_power( 1000 );
			location = this.loc;

			if ( location is Tile ) {
				((dynamic)location).hotspot_expose( 1000, 500, 1 );
			}
			return true;
		}

		// Function from file: igniter.dm
		public override dynamic attack_ai( dynamic user = null ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				return this.ignite();
			} else {
				return null;
			}
		}

		// Function from file: igniter.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Device_DetectiveScanner ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_Screwdriver ) {
				this.add_fingerprint( user );
				this.disable = !this.disable;

				if ( this.disable ) {
					((Ent_Static)user).visible_message( new Txt().item( user ).str( " has disabled " ).the( this ).item().str( "!" ).ToString(), new Txt( "<span class='notice'>You disable the connection to " ).the( this ).item().str( ".</span>" ).ToString() );
					this.icon_state = "" + this.base_state + "-d";
				}

				if ( !this.disable ) {
					((Ent_Static)user).visible_message( new Txt().item( user ).str( " has reconnected " ).the( this ).item().str( "!" ).ToString(), new Txt( "<span class='notice'>You fix the connection to " ).the( this ).item().str( ".</span>" ).ToString() );

					if ( Lang13.Bool( this.powered() ) ) {
						this.icon_state = "" + this.base_state;
					} else {
						this.icon_state = "" + this.base_state + "-p";
					}
				}
			}
			return null;
		}

		// Function from file: igniter.dm
		public override void power_change(  ) {
			
			if ( Lang13.Bool( this.powered() ) && !this.disable ) {
				this.stat &= 65533;
				this.icon_state = "" + this.base_state;
			} else {
				this.stat |= 65533;
				this.icon_state = "" + this.base_state + "-p";
			}
			return;
		}

		// Function from file: igniter.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.spark_system );
			this.spark_system = null;
			return base.Destroy();
		}

	}

}
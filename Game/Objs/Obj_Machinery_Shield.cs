// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Shield : Obj_Machinery {

		public int max_health = 200;
		public double health = 200;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "shield-old";
		}

		// Function from file: shieldgen.dm
		public Obj_Machinery_Shield ( dynamic loc = null ) : base( (object)(loc) ) {
			this.dir = Convert.ToInt32( Rand13.Pick(new object [] { 1, 2, 3, 4 }) );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_update_turf( true );
			return;
		}

		// Function from file: shieldgen.dm
		public void take_damage( dynamic damage = null ) {
			GlobalFuncs.playsound( this.loc, "sound/effects/EMPulse.ogg", 75, 1 );
			this.opacity = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				this.opacity = false;
				return;
			}));
			this.health -= Convert.ToDouble( damage );

			if ( this.health <= 0 ) {
				this.visible_message( "<span class='notice'>" + this + " dissipates.</span>" );
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: shieldgen.dm
		public override bool hitby( Ent_Dynamic AM = null, bool? skipcatch = null, bool? hitpush = null, bool? blocked = null ) {
			dynamic tforce = null;
			Ent_Dynamic O = null;

			tforce = 0;

			if ( AM is Mob ) {
				tforce = 40;
			} else {
				O = AM;
				tforce = ((dynamic)O).throwforce;
			}
			base.hitby( AM, skipcatch, hitpush, blocked );
			this.take_damage( tforce );
			return false;
		}

		// Function from file: shieldgen.dm
		public override bool blob_act( dynamic severity = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: shieldgen.dm
		public override double emp_act( int severity = 0 ) {
			
			switch ((int)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return 0;
		}

		// Function from file: shieldgen.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					
					if ( Rand13.PercentChance( 75 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: shieldgen.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(P), (object)(def_zone) );
			this.take_damage( P.damage );
			return null;
		}

		// Function from file: shieldgen.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A.damtype == "brute" || A.damtype == "fire" ) {
				this.take_damage( A.force );
			}
			return null;
		}

		// Function from file: shieldgen.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			return !this.density;
		}

		// Function from file: shieldgen.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			
			if ( !Lang13.Bool( height ) ) {
				return false;
			} else {
				return base.CanPass( (object)(mover), (object)(target), height, air_group );
			}
		}

		// Function from file: shieldgen.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static T = null;

			T = this.loc;
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.move_update_air( T );
			return false;
		}

		// Function from file: shieldgen.dm
		public override dynamic Destroy(  ) {
			this.opacity = false;
			this.density = false;
			this.air_update_turf( true );
			return base.Destroy();
		}

	}

}
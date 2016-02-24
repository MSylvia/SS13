// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_StepTrigger : Obj_Effect {

		public bool affect_ghosts = false;
		public bool stopper = true;
		public bool mobs_only = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 101;
			this.anchored = 1;
		}

		public Obj_Effect_StepTrigger ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: step_triggers.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			base.Crossed( O, (object)(X) );

			if ( !( O != null ) ) {
				return null;
			}

			if ( O is Mob_Dead_Observer && !this.affect_ghosts ) {
				return null;
			}

			if ( !( O is Mob ) && this.mobs_only ) {
				return null;
			}
			this.Trigger( O );
			return null;
		}

		// Function from file: step_triggers.dm
		public virtual bool Trigger( Ent_Dynamic A = null ) {
			return false;
		}

	}

}
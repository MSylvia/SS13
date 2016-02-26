// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_ParticleAccelerator_ParticleEmitter : Obj_Structure_ParticleAccelerator {

		public int fire_delay = 50;
		public int last_shot = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.desc_holder = "This launchs the Alpha particles, might not want to stand near this end.";
		}

		public Obj_Structure_ParticleAccelerator_ParticleEmitter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: particle_emitter.dm
		public bool emit_particle( int? strength = null ) {
			strength = strength ?? 0;

			Obj_Effect_AcceleratedParticle A = null;
			Tile T = null;

			
			if ( this.last_shot + this.fire_delay <= Game13.time ) {
				this.last_shot = Game13.time;
				A = null;
				T = Map13.GetStep( this, this.dir );

				switch ((int?)( strength )) {
					case 0:
						A = new Obj_Effect_AcceleratedParticle_Weak( T, this.dir );
						break;
					case 1:
						A = new Obj_Effect_AcceleratedParticle( T, this.dir );
						break;
					case 2:
						A = new Obj_Effect_AcceleratedParticle_Strong( T, this.dir );
						break;
					case 3:
						A = new Obj_Effect_AcceleratedParticle_Powerful( T, this.dir );
						break;
				}

				if ( A != null ) {
					A.dir = this.dir;
					return true;
				}
			}
			return false;
		}

		// Function from file: particle_emitter.dm
		public bool set_delay( bool delay = false ) {
			
			if ( delay && ( delay ?1:0) >= 0 ) {
				this.fire_delay = delay ?1:0;
				return true;
			}
			return false;
		}

		// Function from file: particle_emitter.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			return false;
		}

	}

}
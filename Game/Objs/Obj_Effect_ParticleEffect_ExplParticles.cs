// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ParticleEffect_ExplParticles : Obj_Effect_ParticleEffect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon_state = "explosion_particle";
		}

		// Function from file: effects_explosion.dm
		public Obj_Effect_ParticleEffect_ExplParticles ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 15, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

	}

}
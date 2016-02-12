// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_Projectile_MagicMissile : Spell_Targeted_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Magic Missile";
			this.desc = "This spell fires several, slow moving, magic projectiles at nearby targets.";
			this.charge_max = 150;
			this.invocation = "FORTI GY AMA";
			this.invocation_type = "shout";
			this.cooldown_min = 90;
			this.max_targets = 0;
			this.proj_type = typeof(Obj_Item_Projectile_SpellProjectile_Seeking_MagicMissile);
			this.duration = 10;
			this.proj_step_delay = 5;
			this.hud_state = "wiz_mm";
			this.amt_paralysis = 3;
			this.amt_stunned = 3;
			this.amt_dam_fire = 10;
		}

		// Function from file: magic_missile.dm
		public override ByTable prox_cast( ByTable targets = null, Obj_Item_Projectile_SpellProjectile spell_holder = null ) {
			Mob_Living M = null;

			spell_holder.visible_message( new Txt( "<span class='danger'>" ).The( spell_holder ).item().str( " pops with a flash!</span>" ).ToString() );

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				M = _a;
				
				this.apply_spell_damage( M );
			}
			return null;
		}

	}

}
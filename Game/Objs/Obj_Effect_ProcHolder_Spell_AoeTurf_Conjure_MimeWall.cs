// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_MimeWall : Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.school = "mime";
			this.panel = "Mime";
			this.summon_type = new ByTable(new object [] { typeof(Obj_Effect_Forcefield_Mime) });
			this.invocation_type = "emote";
			this.invocation_emote_self = "<span class='notice'>You form a wall in front of yourself.</span>";
			this.summon_lifespan = 300;
			this.charge_max = 300;
			this.clothes_req = 0;
			this.range = 0;
			this.cast_sound = null;
			this.human_req = 1;
			this.action_icon_state = "mime";
			this.action_background_icon_state = "bg_mime";
		}

		public Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_MimeWall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mime.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			
			if ( Task13.User != null && Task13.User.mind != null ) {
				
				if ( !Task13.User.mind.miming ) {
					Task13.User.WriteMsg( "<span class='notice'>You must dedicate yourself to silence first.</span>" );
					return false;
				}
				this.invocation = "<B>" + Task13.User.real_name + "</B> looks as if a wall is in front of them.";
			} else {
				this.invocation_type = "none";
			}
			base.Click( (object)(loc), control, _params );
			return false;
		}

	}

}
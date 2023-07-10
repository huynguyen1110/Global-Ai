const colors = require("tailwindcss/colors");
// tailwind.config.js
module.exports = {
	content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
	media: false,
	theme: {
		extend: {
			colors: {
				...colors,
				'main': '#2d3e99',
			},
			width: {
				'42px': '42px'
			},
			height: {
				'800px': '800px',
				'750px': '750px',
				'650px': '650px',
				'1-7': '1.7rem',
				"95-px": "95px",
				"70-px": "70px",
				"350-px": "350px",
				"500-px": "500px",
				"600-px": "600px",
			},
			backgroundImage: {
				'login': "url('assets/login-form-background.png')",
				'footer': "url('assets/footer-background.png')",
				'list-dichvu': "url('assets/bg/service-background.png')",
			},
			fontSize: {
				'32px': '32px',
				'25px': '25px',
				'14px': '14px',
				'42px': '42px',
				"55": "55rem",
			},
			opacity: {
				"80": ".8",
			},
			zIndex: {
				"2": 2,
				"3": 3,
			},
			inset: {
				"-100": "-100%",
				"-225-px": "-225px",
				"-160-px": "-160px",
				"-150-px": "-150px",
				"-94-px": "-94px",
				"-50-px": "-50px",
				"-29-px": "-29px",
				"-20-px": "-20px",
				"25-px": "25px",
				"40-px": "40px",
				"95-px": "95px",
				"145-px": "145px",
				"195-px": "195px",
				"210-px": "210px",
				"260-px": "260px",
			},
			minHeight: {
				"screen-75": "75vh",
			},
			maxHeight: {
				"860-px": "860px",
			},
			maxWidth: {
				"100-px": "100px",
				"120-px": "120px",
				"150-px": "150px",
				"180-px": "180px",
				"200-px": "200px",
				"210-px": "210px",
				"580-px": "580px",
			},
			minWidth: {
				"140-px": "140px",
				"48": "12rem",
			},
			backgroundSize: {
				full: "100%",
			},
		},
	},
	variants: [
		"responsive",
		"group-hover",
		"focus-within",
		"first",
		"last",
		"odd",
		"even",
		"hover",
		"focus",
		"active",
		"visited",
		"disabled",
	],
	plugins: [require("daisyui")],
	daisyui: {
		styled: true,
		themes: true,
		base: true,
		utils: true,
		logs: true,
		rtl: false,
		prefix: "",
		darkTheme: "dark",
	  },
}

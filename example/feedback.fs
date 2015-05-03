/*{
	"DESCRIPTION": "RGB GLitchMod",
	"CREDIT": "by dantheman",
	"CATEGORIES": [
		"Distortion Effect"
	],
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "offset",
			"TYPE": "float",
			"MIN":0.0,
			"MAX":0.5
		},
		{
			"NAME": "offset_right",
			"TYPE": "float",
			"MIN":0.0,
			"MAX":0.1
		},
		{
		  "NAME": "mix_var",
		  "TYPE":"float",
		  "MIN":0.0,
			"MAX":1.0
		}
  ],
	"PERSISTENT_BUFFERS": [
		"one"
	],
	"PASSES": [
		{
			"TARGET":"one",
			"WIDTH": "$WIDTH",
			"HEIGHT": "$HEIGHT",
			"DESCRIPTION": "buffer"
		}
	]

}*/


void main() {

  vec2 pos = vv_FragNormCoord;
  vec4 old = IMG_NORM_PIXEL(one, pos);
  vec4 new = IMG_NORM_PIXEL(inputImage, pos);
  vec4 U = vec4(0.0);

  U =IMG_NORM_PIXEL(one, vv_FragNormCoord+vec2(offset*0.01))*mix_var + IMG_NORM_PIXEL(one, vv_FragNormCoord-vec2(offset*0.01))*mix_var;


  gl_FragColor =(new)+(U-old/2.0);
}

/**
* Script made by OMA [www.oma.netau.net]
**/

var concrete : AudioClip[];
var wood : AudioClip[];
var dirt : AudioClip[];
var metal : AudioClip[];
private var step : boolean = true;
var audioStepLengthWalk : float = 0.45;
var audioStepLengthRun : float = 0.25;


function OnControllerColliderHit (hit : ControllerColliderHit) {
var controller : CharacterController = GetComponent(CharacterController);

if (controller.isGrounded && controller.velocity.magnitude < 6 && controller.velocity.magnitude > 1.5 && hit.gameObject.tag == "Concrete"  && step == true || controller.isGrounded && controller.velocity.magnitude < 5 && controller.velocity.magnitude > 3 && hit.gameObject.tag == "Untagged" && step == true ) {
		WalkOnConcrete();
	} else if (controller.isGrounded && controller.velocity.magnitude > 10 && hit.gameObject.tag == "Concrete" && step == true || controller.isGrounded && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Untagged" && step == true) {
		RunOnConcrete();
	} else if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 1.5 && hit.gameObject.tag == "Wood" && step == true) {
		WalkOnWood();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Wood" && step == true) {
		RunOnWood();
	} else if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 1.5 && hit.gameObject.tag == "Dirt" && step == true) {
		WalkOnDirt();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Dirt" && step == true) {
		RunOnDirt();
	} else if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 1.5 && hit.gameObject.tag == "Metal" && step == true) {
		WalkOnMetal();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Metal" && step == true) {
		RunOnMetal();		
	} else if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 1.5 && hit.gameObject.tag == "Grass" && step == true) {
		WalkOnGrass();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Grass" && step == true) {
		RunOnGrass();		
	}	
}

/////////////////////////////////// CONCRETE ////////////////////////////////////////
function WalkOnConcrete() {
	step = false;
	GetComponent.<AudioSource>().clip = concrete[Random.Range(0, concrete.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnConcrete() {
	step = false;
	GetComponent.<AudioSource>().clip = concrete[Random.Range(0, concrete.length)];
	GetComponent.<AudioSource>().volume = .5;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}	


////////////////////////////////// WOOD /////////////////////////////////////////////
function WalkOnWood() {
	step = false;
	GetComponent.<AudioSource>().clip = wood[Random.Range(0, wood.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnWood() {
	step = false;
	GetComponent.<AudioSource>().clip = wood[Random.Range(0, wood.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}


/////////////////////////////////// DIRT //////////////////////////////////////////////
function WalkOnDirt() {
	step = false;
	GetComponent.<AudioSource>().clip = dirt[Random.Range(0, dirt.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnDirt() {
	step = false;
	GetComponent.<AudioSource>().clip = dirt[Random.Range(0, dirt.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}


////////////////////////////////// METAL ///////////////////////////////////////////////
function WalkOnMetal() {	
	step = false;
	GetComponent.<AudioSource>().clip = metal[Random.Range(0, metal.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnMetal() {
	step = false;
	GetComponent.<AudioSource>().clip = metal[Random.Range(0, metal.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}


function WalkOnGrass() {
	
	step = false;
	GetComponent.<AudioSource>().clip = dirt[Random.Range(0, metal.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnGrass() {
	step = false;
	GetComponent.<AudioSource>().clip = dirt[Random.Range(0, metal.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}

@script RequireComponent(AudioSource)
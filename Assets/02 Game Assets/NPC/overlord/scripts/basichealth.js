#pragma strict
var health : float = 100f;

function Start () {

}

function Update () {

}
function Damage(damage : float)
{
	health -= damage;
}
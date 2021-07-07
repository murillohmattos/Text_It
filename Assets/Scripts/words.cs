using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI; //Interface
using System.Text.RegularExpressions; //Configurações de case-sensitive


public class words : MonoBehaviour
{
	//Class
	ButtonWord buttonWord;

    //Particle system
    public ParticleSystem ps;
	
	//Condições para ganhar ou perder
	public GameObject lose;
	public GameObject win;

    //Variaveis dos objetos
    public GameObject[] sprite = new GameObject[15];//Array com prefabs das palavras
    List<GameObject> spriteName = new List<GameObject>();

    public GameObject[] imagensGO = new GameObject[15];
    List<GameObject> imagensList = new List<GameObject>();

    public int count = 0;//Contador do Array Sprite
    int count2 = 0;
	int count3 = 0;//Contador Backend de derrota

    //Vamos criar o tempo
    private float spawn = 0.0f;
    public float periodo;
	public float timeLimit;
	float timeLose = 0.0f;

    //Validação do texto
	public InputField stringToEdit;	
	public Text timer;
	public Text points;	

	//Pontuação e nível
	string pontos = "0";
    string nivel = "0";
    int pt = 0;
	public int ptSoma;
	public int ptTotal;
    int nv = 0;


    //Variaveis de audio
    

    private void Start()
    {
		timeLose = Time.timeSinceLevelLoad + timeLimit;
		Debug.Log(timeLose.ToString());

		Time.timeScale = 1;//Faz com que inicie o tempo, evitando bugs de pause de niveis anteriores

        buttonWord = GetComponent<ButtonWord>();
		stringToEdit.Select();
		Score();

		//instancia imagem da palavra
		imagensList.Add(Instantiate(imagensGO[count2], new Vector2(0f, 0f), Quaternion.identity));
		imagensList[count2].transform.SetParent(GameObject.FindGameObjectWithTag("Icons").transform, false);
	}

	private void Update()
    {
		timer.text = Time.timeSinceLevelLoad.ToString("f0");
        
        Physics2D.gravity = new Vector2(0f, -5.0f);//Gravidade da queda das palavras	

		Victory();

		if (Time.timeSinceLevelLoad > spawn)
        {            
            spawn += periodo;//Aumenta o periodo de contagem para o quanto estiver em periodo            

			sprite[count].name = imagensGO[count].name;
			buttonWord.SetupLabel();

			//instancia a palavra e joga pra lista 
			spriteName.Add(Instantiate(sprite[count], new Vector2(-3.75f, 5.50f), Quaternion.identity)); 
			
			//Configura a palavra instanciada como filho de um GameObject
			spriteName[count].transform.SetParent(GameObject.FindGameObjectWithTag("Instantiated").transform, false);					

			count++;//aumenta o contador 1
			count3++;//contador soma a cada palavra adicionada			
		}
		

		if (Regex.IsMatch(stringToEdit.text, imagensGO[count2].name, RegexOptions.IgnoreCase))//se o que for digitado é igual a palavra[contador]
		{
            ps.Play();
            Destroy(imagensList[count2]);
			Destroy(spriteName[count2]);
            
            count2++;
			count3--; //O contador diminui quando a palavra for acertada

			pt = pt + ptSoma;//Soma de pontos
			Score();		

			//instancia imagem da palavra
			imagensList.Add(Instantiate(imagensGO[count2], new Vector2(0f, 0f), Quaternion.identity));
			imagensList[count2].transform.SetParent(GameObject.FindGameObjectWithTag("Icons").transform, false);			
            
            Debug.Log("Counts atuais Count: " + count + "Count2: " + count2 + "Count3: " + count3);
            
            
            stringToEdit.text = "";

			if (periodo > 2.5f)//Aumenta a velocidade que irá surgir uma nova palavra
			{
				periodo -= 0.5f;//
			}

			if (pt % 2 == 0)
			{
                nv++;
			}
        }
       
    }

	void Score()
	{
		points.text = pt.ToString();
	}

	void Victory()
	{
		//Validação de vitória e derrota
		if (pt >= ptTotal)
		{
			win.SetActive(true);
			Time.timeScale = 0f;
		}

		if (count3 >= 9 ^ Time.timeSinceLevelLoad > timeLose)
		{
			lose.SetActive(true);
			Time.timeScale = 0f;
		}
	}
}

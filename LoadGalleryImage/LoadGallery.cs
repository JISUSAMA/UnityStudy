using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class LoadGallery : MonoBehaviour
{
    /* 패키지 매니저 다운 주소 : https://github.com/yasirkula/unitynativegallery */
    public RawImage loadImg;
    public void OnClick_GalleryFile()
    {   
        //이미지를 선택파일을 열었음
        NativeGallery.GetImageFromGallery((file)=> 
        {
            //선택한 이미지가 뭔지 알아야함
            FileInfo seleted = new FileInfo(file);
            //용량 제한하기 50000000바이트
            if(seleted.Length > 50000000) { return; }
            //불러오기
            if (!string.IsNullOrEmpty(file))
            {
                //file이 비어있지 않으면 불러와라 
                StartCoroutine(_LoadImage(file));
            }
        
        });
    }
    IEnumerator _LoadImage(string path)
    {
        yield return null;

        byte[] fileData = File.ReadAllBytes(path);
        string fileName = Path.GetFileName(path).Split('.')[0]; //확장자 명은 가져오지 않고 이름만 가져옴
        //한번불러오고 다시 파일로 들어가서 불러오지 않아도되도록 Path 를 저장해둠
        string savePath = Application.persistentDataPath + "/Image";

        //이미지 폴더가 존재 하지 않으면 
        if (!Directory.Exists(savePath))
        {
            //경로, 파일을 만들어줌
            Directory.CreateDirectory(savePath);
        }
        File.WriteAllBytes(savePath + fileName+ ".png", fileData); //파일을 경로 안에 저장함
        var temp = File.ReadAllBytes(savePath + fileName + ".png");  //경로 안의 이미지를 불러옴
        
        //temp는 바이트 형태이기 떄문에 texture형태로 변형해주어야함
        Texture2D te2x = new Texture2D(0, 0);
        te2x.LoadImage(temp);

        loadImg.texture = te2x;

        //loadImg의 크키에 맞춰서 이미지가 바뀌는 문제가 있음
        //loadImg.SetNativeSize(); // 이미지의 원래 원본 사이즈로 불러옴
       
        
        ImageSizeSetting(loadImg, 1000, 1000);
    }
    //이미지 사이즈에 따라서 이미지 조절하는 방법
    void ImageSizeSetting(RawImage img, float x, float y)
    {
        var imgX = img.rectTransform.sizeDelta.x; //이미지의 가로 길이 
        var imgY = img.rectTransform.sizeDelta.y; //이미지의 세로 길이

        if (x / y > imgX / imgY) //이미지의 세로 길이가 더 길다 
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y); //원본이 imgY인데 y로 바뀜 => imgY * (y/imgY) = y과 같음 
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgX * (y / imgY));
        }
        else //가로의 길이가 더 길다. 
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x); //원본이 imgX인데 x로 바뀜 => imgX * (x/imgX) = x과 같음 
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imgY * (x / imgX));
        }
    }
}

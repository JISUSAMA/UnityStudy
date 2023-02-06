using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class LoadGallery : MonoBehaviour
{
    /* ��Ű�� �Ŵ��� �ٿ� �ּ� : https://github.com/yasirkula/unitynativegallery */
    public RawImage loadImg;
    public void OnClick_GalleryFile()
    {   
        //�̹����� ���������� ������
        NativeGallery.GetImageFromGallery((file)=> 
        {
            //������ �̹����� ���� �˾ƾ���
            FileInfo seleted = new FileInfo(file);
            //�뷮 �����ϱ� 50000000����Ʈ
            if(seleted.Length > 50000000) { return; }
            //�ҷ�����
            if (!string.IsNullOrEmpty(file))
            {
                //file�� ������� ������ �ҷ��Ͷ� 
                StartCoroutine(_LoadImage(file));
            }
        
        });
    }
    IEnumerator _LoadImage(string path)
    {
        yield return null;

        byte[] fileData = File.ReadAllBytes(path);
        string fileName = Path.GetFileName(path).Split('.')[0]; //Ȯ���� ���� �������� �ʰ� �̸��� ������
        //�ѹ��ҷ����� �ٽ� ���Ϸ� ���� �ҷ����� �ʾƵ��ǵ��� Path �� �����ص�
        string savePath = Application.persistentDataPath + "/Image";

        //�̹��� ������ ���� ���� ������ 
        if (!Directory.Exists(savePath))
        {
            //���, ������ �������
            Directory.CreateDirectory(savePath);
        }
        File.WriteAllBytes(savePath + fileName+ ".png", fileData); //������ ��� �ȿ� ������
        var temp = File.ReadAllBytes(savePath + fileName + ".png");  //��� ���� �̹����� �ҷ���
        
        //temp�� ����Ʈ �����̱� ������ texture���·� �������־����
        Texture2D te2x = new Texture2D(0, 0);
        te2x.LoadImage(temp);

        loadImg.texture = te2x;

        //loadImg�� ũŰ�� ���缭 �̹����� �ٲ�� ������ ����
        //loadImg.SetNativeSize(); // �̹����� ���� ���� ������� �ҷ���
       
        
        ImageSizeSetting(loadImg, 1000, 1000);
    }
    //�̹��� ����� ���� �̹��� �����ϴ� ���
    void ImageSizeSetting(RawImage img, float x, float y)
    {
        var imgX = img.rectTransform.sizeDelta.x; //�̹����� ���� ���� 
        var imgY = img.rectTransform.sizeDelta.y; //�̹����� ���� ����

        if (x / y > imgX / imgY) //�̹����� ���� ���̰� �� ��� 
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y); //������ imgY�ε� y�� �ٲ� => imgY * (y/imgY) = y�� ���� 
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgX * (y / imgY));
        }
        else //������ ���̰� �� ���. 
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x); //������ imgX�ε� x�� �ٲ� => imgX * (x/imgX) = x�� ���� 
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imgY * (x / imgX));
        }
    }
}

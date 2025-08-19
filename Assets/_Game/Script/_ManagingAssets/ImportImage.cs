using UnityEditor;
using UnityEngine;

public class ImportImage : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter importer = (TextureImporter)assetImporter;

        if (assetPath.ToLower().EndsWith(".png"))
        {
            // Loại texture: Sprite
            importer.textureType = TextureImporterType.Sprite;

            // Import sprite dạng Single
            importer.spriteImportMode = SpriteImportMode.Single;

            // Không dùng mipmap (2D không cần)
            importer.mipmapEnabled = false;

            // Pixel art → dùng Point filter
            importer.filterMode = FilterMode.Point;

            // Không nén → giữ chất lượng cao nhất
            importer.textureCompression = TextureImporterCompression.Uncompressed;

            // Pixels Per Unit
            importer.spritePixelsPerUnit = 128;

            // Max Size
            importer.maxTextureSize = 2048;

            Debug.Log("✅ Imported PNG as Sprite with custom settings: " + assetPath);
        }
    }
}

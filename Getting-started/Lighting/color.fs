#version 330 core
struct Material{//材质结构体
    vec3 ambient;//环境光反射颜色
    vec3 diffuse;//漫反射物体颜色
    vec3 specular;//镜面光照对物体的影响
    float shininess;//反光度，影响镜面高光的散射/半径
};
struct Light{//光照属性结构体
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
out vec4 FragColor;

in vec3 Normal;
in vec3 FragPos;

uniform vec3 viewPos;
uniform Material material;
uniform Light light;

void main()
{
    // 环境光
    vec3 ambient = light.ambient * material.ambient;

    // 漫反射 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * (diff * material.diffuse);

    // 镜面光
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * (spec * material.specular);  

    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}
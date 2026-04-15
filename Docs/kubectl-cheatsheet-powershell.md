# Kubectl Cheat Sheet (PowerShell-focused)

## 1. Kubeconfig + contexts

### Brug flere kubeconfigs (midlertidigt)
```powershell
$env:KUBECONFIG="$HOME\.kube\config;C:\path\to\new-config.yaml"
```

### Merge kubeconfigs (permanent)
```powershell
kubectl config view --merge --flatten | Out-File -Encoding utf8 $HOME\.kube\config
```

### Se contexts
```powershell
kubectl config get-contexts
```

### Skift context
```powershell
kubectl config use-context <context-name>
```

### Se aktiv context
```powershell
kubectl config current-context
```

---

## 2. Apply / Deploy

### Deploy YAML
```powershell
kubectl apply -f deployment.yaml
```

### Deploy folder
```powershell
kubectl apply -f .\k8s\
```

---

## 3. Slet resources

```powershell
kubectl delete -f deployment.yaml
kubectl delete deployment <name>
kubectl delete pod <name>
kubectl delete service <name>
```

---

## 4. Inspect / Debug

### Get resources
```powershell
kubectl get pods
kubectl get deployments
kubectl get services
```

### Describe (meget vigtig)
```powershell
kubectl describe pod <pod-name>
kubectl describe deployment <name>
```

---

## 5. Logs

### Se logs
```powershell
kubectl logs <pod-name>
```

### Følg logs live
```powershell
kubectl logs -f <pod-name>
```

### Container logs
```powershell
kubectl logs <pod-name> -c <container-name>
```

---

## 6. Rollout (deployments)

```powershell
kubectl rollout status deployment/<name>
kubectl rollout restart deployment/<name>
kubectl rollout undo deployment/<name>
```

---

## 7. Edit live

```powershell
kubectl edit deployment <name>
```

---

## 8. Cluster / troubleshooting

```powershell
kubectl cluster-info
kubectl get nodes
kubectl config view
kubectl config get-contexts
```

---

## 9. Namespace

```powershell
kubectl get pods -n <namespace>
kubectl config set-context --current --namespace=dev
```

---

## 10. Bonus workflow

### Add kubeconfig
```powershell
$env:KUBECONFIG="$HOME\.kube\config;.\TheParcelApplication-kubeconfig.yml"
```

### Download Kubeconfig
```powershell
kubectl config view --minify --raw | Out-File -Encoding utf8 .\kubeconfig.yaml
```

### Merge
```powershell
kubectl config view --merge --flatten | Out-File -Encoding utf8 $HOME\.kube\config
```

### Switch cluster
```powershell
kubectl config use-context minikube
kubectl config use-context <linode-context>
```

---

## 11. Bonus alias

```powershell
Set-Alias k kubectl
```

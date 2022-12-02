Run these commands in sequence inside k8s folder to be able to spin up the rabbitmq cluster.

Default user/password are guest/guest.

UI address: http://localhost:15672

```
kubectl create ns rabbits
```

```
kubectl create -n rabbits -f configmap.yaml
```

```
kubectl create -n rabbits -f rbac.yaml
```

```
kubectl create -n rabbits -f secret.yaml
```

```
kubectl create -n rabbits -f statefulset.yaml
```
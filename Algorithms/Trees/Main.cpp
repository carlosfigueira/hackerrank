// CPPConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include <stdio.h>
#include <stdarg.h>

struct Node {
	int data;
	struct Node *next;
	struct Node *prev;
	bool isDouble;
};

Node * insert(Node *head, int data);
Node * create(int count, ...);
void print(Node *head);
void release(Node *head);
Node *reverseInPlace(Node *head);
Node *reverseInPlaceDouble(Node *head);
Node *createDouble(int count, ...);
Node *insertDouble(Node *head, int data);

Node * createDouble(int count, ...) {
	va_list ap;
	int i;
	Node *head = NULL;
	va_start(ap, count);
	for (int i = 0; i < count; i++) {
		head = insertDouble(head, va_arg(ap, int));
	}
	va_end(ap);
	return head;
}
Node * insertDouble(Node *head, int data) {
	Node *newNode = new Node();
	newNode->data = data;
	newNode->next = NULL;
	newNode->prev = NULL;
	newNode->isDouble = true;
	if (head) {
		Node *prev = head;
		Node *curr = head->next;
		while (curr) {
			prev = curr;
			curr = curr->next;
		}
		prev->next = newNode;
		newNode->prev = prev;
		return head;
	}
	else {
		return newNode;
	}
}

Node * create(int count, ...) {
	va_list ap;
	int i;
	Node *head = NULL;
	va_start(ap, count);
	for (int i = 0; i < count; i++) {
		head = insert(head, va_arg(ap, int));
	}
	va_end(ap);
	return head;
}
Node * insert(Node *head, int data) {
	Node *newNode = new Node();
	newNode->data = data;
	newNode->next = NULL;
	newNode->isDouble = false;
	if (head) {
		Node *prev = head;
		Node *curr = head->next;
		while (curr) {
			prev = curr;
			curr = curr->next;
		}
		prev->next = newNode;
		return head;
	}
	else {
		return newNode;
	}
}
void print(Node *head) {
	bool isDouble = head && head->isDouble;
	if (head && isDouble) {
		printf("NULL <-> ");
	}

	Node *prev = NULL;
	while (head) {
		printf("%d %s ", head->data, head->isDouble ? "<->" : "->");
		prev = head;
		head = head->next;
	}
	printf("NULL\n");
	if (isDouble && prev) {
		printf("  Reverse: ");
		while (prev) {
			printf("%d ..> ", prev->data);
			prev = prev->prev;
		}
		printf("NULL\n");
	}
}
void release(Node *head) {
	if (head) {
		release(head->next);
		delete head;
	}
}
Node *reverseInPlace(Node *head) {
	if (!head || !head->next) return head;
	Node *prev = head;
	Node *curr = head->next;
	Node *next = head->next->next;
	head->next = NULL;
	Node *newHead = NULL;
	while (curr) {
		newHead = curr;
		curr->next = prev;
		prev = curr;
		curr = next;
		if (next) {
			next = next->next;
		}
	}

	return newHead;
}
Node *reverseInPlaceDouble(Node *head) {
	if (!head || !head->next) return head;
	Node *curr = head;
	Node *next = head->next;
	Node *newHead = NULL;
	while (curr) {
		newHead = curr;
		Node *temp = curr->next;
		curr->next = curr->prev;
		curr->prev = temp;
		curr = temp;
	}

	return newHead;
}
int GetNodeFromEnd(Node *head, int currentPosition, int positionFromTail, int *pLength) {
	if (head) {
		*pLength = *pLength + 1;
		int temp = GetNodeFromEnd(head->next, currentPosition + 1, positionFromTail, pLength);
		if (currentPosition + positionFromTail + 1 == *pLength) {
			return head->data;
		}
		else {
			return temp;
		}
	}
	else {
		return -1;
	}
}
int GetNode(Node *head, int positionFromTail) {
	int length = 0;
	return GetNodeFromEnd(head, 0, positionFromTail, &length);
}
Node *RemoveDuplicates(Node *head) {
	if (!head) return head;
	Node *result = head;
	while (head && head->next && head->next->data == head->data) {
		Node *temp = head->next;
		head->next = head->next->next;
		delete temp;
	}
	head->next = RemoveDuplicates(head->next);
	return head;
}
bool has_cycle(Node *head) {
	if (!head || !head->next) return false;
	Node *temp1 = head;
	Node *temp2 = head->next;
	while (temp1 != temp2) {
		temp2 = temp2->next;
		if (!temp2) return false;
		temp2 = temp2->next;
		if (!temp2) return false;
		temp1 = temp1->next;
	}

	return true;
}
struct pNode {
	Node *node;
	struct pNode *next;
};
pNode *reversePointers(Node *head) {
	if (!head) return NULL;
	pNode *result = NULL;
	while (head) {
		pNode *newNode = new pNode();
		newNode->node = head;
		newNode->next = result;
		result = newNode;
		head = head->next;
	}
	return result;
}
void releasePNodes(pNode *head) {
	if (!head) return;
	releasePNodes(head->next);
	delete head;
}
int FindMergeNode(Node *headA, Node *headB) {
	pNode *stackA = reversePointers(headA);
	pNode *stackB = reversePointers(headB);
	Node *prev = NULL;
	pNode *tempA = stackA;
	pNode *tempB = stackB;
	while (tempA->node == tempB->node) {
		prev = tempA->node;
		tempA = tempA->next;
		tempB = tempB->next;
	}
	releasePNodes(stackA);
	releasePNodes(stackB);
	return prev->data;
}
void TestFindMergeNode() {
	Node *headA = create(6, 1, 2, 3, 24, 25, 26);
	Node *headB = create(2, 11, 12);
	headB->next->next = headA->next->next->next;
	printf("Merge node (should be 24): %d\n", FindMergeNode(headA, headB));
	headB->next->next = NULL;
	release(headA);
	release(headB);
}
Node *sortedInsert(Node *head, int data) {
	Node *newNode = insertDouble(NULL, data);
	if (!head) {
		return newNode;
	}
	else if (data <= head->data) {
		newNode->next = head;
		head->prev = newNode;
		return newNode;
	}
	else {
		Node *prev = head;
		while (prev->next && prev->next->data < data) {
			prev = prev->next;
		}
		newNode->prev = prev;
		newNode->next = prev->next;
		if (prev->next) {
			prev->next->prev = newNode;
		}
		prev->next = newNode;
		return head;
	}
}
void TestSortedInsertDouble() {
	// https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list
	Node *node = NULL;
	node = sortedInsert(node, 2);
	print(node);
	release(node);
	node = createDouble(3, 2, 4, 6);
	node = sortedInsert(node, 5);
	print(node);
	release(node);
	node = createDouble(3, 2, 4, 6);
	node = sortedInsert(node, 1);
	print(node);
	release(node);
	node = createDouble(3, 2, 4, 6);
	node = sortedInsert(node, 7);
	print(node);
	release(node);
}
void TestReverseInPlaceDouble() {
	Node *node = NULL;
	node = reverseInPlaceDouble(node);
	print(node);
	node = createDouble(1, 1);
	node = reverseInPlaceDouble(node);
	print(node);
	release(node);
	node = createDouble(2, 1, 2);
	node = reverseInPlaceDouble(node);
	print(node);
	release(node);
	node = createDouble(6, 1, 2, 3, 4, 5, 6);
	node = reverseInPlaceDouble(node);
	print(node);
	release(node);
}
int main()
{
	Node *node;
	node = createDouble(5, 1, 2, 3, 4, 5);
	print(node);
	release(node);
	node = create(4, 1, 3, 5, 6);
	print(node);
	int fromTail = GetNode(node, 0);
	printf("GetNode(node, 0) = %d\n", fromTail);
	fromTail = GetNode(node, 2);
	printf("GetNode(node, 2) = %d\n", fromTail);
	release(node);

	TestReverseInPlaceDouble();
	TestSortedInsertDouble();

	node = create(1, 1);
	node = reverseInPlace(node);
	print(node);
	release(node);
	node = create(2, 1, 2);
	node = reverseInPlace(node);
	print(node);
	release(node);
	node = create(5, 1, 2, 3, 4, 5);
	node = reverseInPlace(node);
	print(node);
	release(node);

	node = NULL;
	printf("Empty list: ");
	print(node);
	node = RemoveDuplicates(node);
	printf("Empty list (after removing duplicates): ");
	print(node);

	node = create(7, 1, 1, 3, 3, 5, 6, 6);
	printf("List: ");
	print(node);
	node = RemoveDuplicates(node);
	printf("List after removing duplicates: ");
	print(node);
	release(node);

	printf("\nhttps://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle\n\n");
	node = NULL;
	printf("Cycle in NULL list? %d\n", has_cycle(node) ? 1 : 0);
	node = create(1, 1);
	printf("Cycle in 1-element list? %d\n", has_cycle(node) ? 1 : 0);
	node->next = node;
	printf("Cycle in 1-element cyclic list? %d\n", has_cycle(node) ? 1 : 0);
	node->next = NULL;
	release(node);
	node = create(2, 1, 2);
	printf("Cycle in 2-element list? %d\n", has_cycle(node) ? 1 : 0);
	node->next->next = node;
	printf("Cycle in 2-element cyclic list? %d\n", has_cycle(node) ? 1 : 0);
	node->next->next = node->next;
	printf("Cycle in 2-element cyclic list? %d\n", has_cycle(node) ? 1 : 0);
	node->next->next = NULL;
	release(node);
	node = create(3, 1, 2, 3);
	printf("Cycle in 3-element list? %d\n", has_cycle(node) ? 1 : 0);
	node->next->next->next = node;
	printf("Cycle in 3-element cyclic list? %d\n", has_cycle(node) ? 1 : 0);
	node->next->next->next = node->next;
	printf("Cycle in 3-element cyclic list? %d\n", has_cycle(node) ? 1 : 0);
	node->next->next->next = NULL;
	release(node);

	printf("\nhttps://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists\n\n");
	TestFindMergeNode();

	return 0;
}
